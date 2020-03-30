using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        Graphics g;
        Bitmap buf;
        int stage1 = 0, stage2 = 0, stage3 = 0, stage4 = 0, stage5 = 0, stage6 = 0;
        int x1 = 130, y1 = 100, x2 = 350, y2 = 100, x3 = 220;
        int k = 0;
        public Form1()
        {
            InitializeComponent();
            buf = new Bitmap(Properties.Resources.Kahns_Kave);//Определение буфера
            g = Graphics.FromImage(buf);//Определение графики из буфера
            imageList1.Draw(g, new Point(x1, y1), stage1);
            imageList2.Draw(g, new Point(x2, y2), stage2);
            imageList6.Draw(g, new Point(45, 28), stage6);
            pictureBox1.Image = buf;
        }      
        private void timer1_Tick(object sender, EventArgs e)
        {
            k++;
            buf = new Bitmap(Properties.Resources.Kahns_Kave);
            g = Graphics.FromImage(buf);
            if (x1 < 211)
            {
                imageList6.Draw(g, new Point(45, 28), stage6);
                imageList4.Draw(g, new Point(x1, y1), stage4);
                imageList3.Draw(g, new Point(x2, y2), stage3);
                x1 += 10;
                x2 -= 10;
                stage3++;
                stage4++;                
            }
            if (k > 9 && k < 22)
            {
                imageList6.Draw(g, new Point(45, 28), stage6);
                imageList1.Draw(g, new Point(x1, y1), stage1);
                stage1++;
                imageList2.Draw(g, new Point(x2, y2), stage2);
                if (stage2 < 3) stage2++;
            }
            if (k > 21 && k < 35)
            {
                imageList6.Draw(g, new Point(45, 28), stage6);
                imageList2.Draw(g, new Point(x2, y2), stage2);
                if(k < 35) stage2++;
                if(k < 33) imageList1.Draw(g, new Point(x3, y1), stage1);
                if (k > 28 && k < 32)
                {
                    imageList6.Draw(g, new Point(45, 28), stage6);
                    stage6++;
                } 
                if (k > 27 && k < 33)
                {                    
                    stage1++;
                    x3 -= 20;
                }
                if (k > 32) imageList5.Draw(g, new Point(x3, y1 + 70), stage5);
            }
            if(k > 34 && k < 39)
            {
                imageList6.Draw(g, new Point(45, 28), stage6);
                imageList5.Draw(g, new Point(x3, y1 + 70), stage5);
                imageList2.Draw(g, new Point(x2, y2), stage2);
                stage2++;
            }      
            if(k < 39) pictureBox1.Image = buf;
            if(k == 39) textBox3.Visible = true;
        }
       
        Boolean bl = false;
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = bl;
            bl = !bl;
            timer1.Enabled = bl;           
        }
    }
}
