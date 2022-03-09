using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace puzzle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int HareketSayisi = 0;
        int labelIndex = 0;
        private void buttonkaristir()
        {
            List<int> LabelList = new List<int>();
            Random rnd = new Random();
            foreach(Button btn in this.panel1.Controls)
            {
                while (LabelList.Contains(labelIndex))
                {
                    labelIndex = rnd.Next(16);
                }
                btn.Text = (labelIndex == 0) ? "" : labelIndex + "";
                btn.BackColor = (btn.Text == "") ? Color.White : Color.FromKnownColor(KnownColor.ControlLight);
                LabelList.Add(labelIndex);


            }

        }
        private void yerDegistir(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (btn.Text == "")
                return;

            Button whiteBtn = null;

            foreach(Button bt in this.panel1.Controls)
            {
                if (bt.Text == "")
                {
                    whiteBtn = bt;
                    break;
                } 
            
            }

            if ( btn.TabIndex==(whiteBtn.TabIndex-1)||
                 btn.TabIndex == (whiteBtn.TabIndex - 4) ||
                  btn.TabIndex == (whiteBtn.TabIndex + 1) ||
                   btn.TabIndex == (whiteBtn.TabIndex + 4))
            {
                whiteBtn.BackColor = Color.FromKnownColor(KnownColor.ControlLight);
                btn.BackColor = Color.White;
                whiteBtn.Text = btn.Text;
                btn.Text = "";
                HareketSayisi++;
                label1.Text = "Hareket Sayisi:" + HareketSayisi;

            }
            Kontrol();
           
        }
        private void Kontrol()
        {
            int index = 0;
            foreach (Button bt in this.panel1.Controls)
            {
                if (bt.Text != "" && Convert.ToInt16(bt.Text) != index)
                {
                    return;
                }
                index++;
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            buttonkaristir();
            


        }

        private void button17_Click(object sender, EventArgs e)
        {
            HareketSayisi = 0;
            label1.Text = "Hareket Sayisi:" + HareketSayisi;
            buttonkaristir();
        }
    }
}
