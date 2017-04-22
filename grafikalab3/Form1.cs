using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;

namespace grafikalab3
{
    public partial class Form1 : Form
    {

        private System.Drawing.Pen pen1 = new System.Drawing.Pen(Color.Red, 2);
        private System.Drawing.Pen pen2 = new System.Drawing.Pen(Color.Blue, 2);
        private System.Drawing.Pen pen3 = new System.Drawing.Pen(Color.Black, 2);
        private System.Drawing.Brush pen4 = new System.Drawing.SolidBrush(Color.Green);

        public Form1()
        {
            InitializeComponent();
        }

        private void Draw1_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics gr = Graphics.FromImage(bmp);

            gr.DrawLine(pen3, 0, pictureBox1.Height / 2, pictureBox1.Width, pictureBox1.Height / 2);
            gr.DrawLine(pen3, pictureBox1.Width / 2, 0, pictureBox1.Width / 2, pictureBox1.Height);

            Point[] punkty = new Point[4];
            int tmp = 0;


            int.TryParse(textBox1.Text, out tmp);
            punkty[0].X = tmp;
            int.TryParse(textBox2.Text, out tmp);
            punkty[0].Y = tmp;

            int.TryParse(textBox3.Text, out tmp);
            punkty[1].X = tmp;
            int.TryParse(textBox4.Text, out tmp);
            punkty[1].Y = tmp;

            int.TryParse(textBox5.Text, out tmp);
            punkty[2].X = tmp;
            int.TryParse(textBox6.Text, out tmp);
            punkty[2].Y = tmp;

            int.TryParse(textBox7.Text, out tmp);
            punkty[3].X = tmp;
            int.TryParse(textBox8.Text, out tmp);
            punkty[3].Y = tmp;

            Point punkt_przeciecia = new Point();

            double delta = (double)(punkty[1].X - punkty[0].X) * (double)(punkty[2].Y - punkty[3].Y) - (double)(punkty[2].X - punkty[3].X) * (double)(punkty[1].Y - punkty[0].Y);
            double delta_mi = 0;
            double mi;

            gr.DrawLine(pen1, punkty[0].X + pictureBox1.Width / 2, (-1) * punkty[0].Y + pictureBox1.Height / 2, punkty[1].X + pictureBox1.Width / 2, (-1) * punkty[1].Y + pictureBox1.Height / 2);
            gr.DrawLine(pen2, punkty[2].X + pictureBox1.Width / 2, (-1) * punkty[2].Y + pictureBox1.Height / 2, punkty[3].X + pictureBox1.Width / 2, (-1) * punkty[3].Y + pictureBox1.Height / 2);

            if (delta != 0)
            {
                delta_mi = (double)(punkty[2].X - punkty[0].X) * (double)(punkty[2].Y - punkty[3].Y) - (double)(punkty[2].X - punkty[3].X) * (double)(punkty[2].Y - punkty[0].Y);
                mi = delta_mi / delta;
                punkt_przeciecia.X = (int)((1 - mi) * punkty[0].X + mi * punkty[1].X);
                punkt_przeciecia.Y = (int)((1 - mi) * punkty[0].Y + mi * punkty[1].Y);

                textBox9.Text = punkt_przeciecia.X.ToString();
                textBox10.Text = punkt_przeciecia.Y.ToString();

                gr.FillEllipse(pen4, punkt_przeciecia.X + pictureBox1.Width / 2 - 5, -1 * punkt_przeciecia.Y + pictureBox1.Height / 2 - 5, 10, 10);
            }
            else
                MessageBox.Show("Proste dla podanych punktów są równoległe.");

            pictureBox1.Image = bmp;

        }

        private void Draw2_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics gr = Graphics.FromImage(bmp);

            gr.DrawLine(pen3, 0, pictureBox1.Height / 2, pictureBox1.Width, pictureBox1.Height / 2);
            gr.DrawLine(pen3, pictureBox1.Width / 2, 0, pictureBox1.Width / 2, pictureBox1.Height);

            Point po1 = new Point(), po2 = new Point();
            double a = 0, b = 0, c = 0, d = 0, teta = 0;
            double tmp = 0;

            double.TryParse(textBox11.Text, out tmp);
            po1.X = (int)tmp;
            double.TryParse(textBox12.Text, out tmp);
            po1.Y = (int)tmp;

            double.TryParse(textBox13.Text, out tmp);
            po2.X = (int)tmp;
            double.TryParse(textBox14.Text, out tmp);
            po2.Y = (int)tmp;

            double l1, l2;
            l1 = Math.Pow((Math.Pow(po1.X, 2) + Math.Pow(po1.Y, 2)), 0.5);
            l2 = Math.Pow((Math.Pow(po2.X, 2) + Math.Pow(po2.Y, 2)), 0.5);

            a = po1.X / l1;
            b = po1.Y / l1;
            c = po2.X / l2;
            d = po2.Y / l2;

            double acbd = a * c + b * d;
            if (acbd > 0)
                teta = Math.Acos(acbd);
            else
                teta = Math.Acos((1) * acbd);

            gr.DrawLine(pen2, pictureBox1.Width / 2, pictureBox1.Height / 2, po1.X + pictureBox1.Width / 2, (-1) * po1.Y + pictureBox1.Height / 2);
            gr.DrawLine(pen1, pictureBox1.Width / 2, pictureBox1.Height / 2, po2.X + pictureBox1.Width / 2, (-1) * po2.Y + pictureBox1.Height / 2);

            textBox15.Text = (teta * 180.0 / Math.PI).ToString();

            pictureBox1.Image = bmp;

        }

        private void Count1_Click(object sender, EventArgs e)
        {
            
            Point3D[] punkty3D = new Point3D[5];
            double k, mi;
            double tmp = 0;

            double.TryParse(textBox16.Text, out tmp);
            punkty3D[0].X = (int)tmp;
            double.TryParse(textBox17.Text, out tmp);
            punkty3D[0].Y = (int)tmp;
            double.TryParse(textBox18.Text, out tmp);
            punkty3D[0].Z = (int)tmp;

            double.TryParse(textBox19.Text, out tmp);
            punkty3D[1].X = (int)tmp;
            double.TryParse(textBox20.Text, out tmp);
            punkty3D[1].Y = (int)tmp;
            double.TryParse(textBox21.Text, out tmp);
            punkty3D[1].Z = (int)tmp;

            double.TryParse(textBox22.Text, out tmp);
            punkty3D[2].X = (int)tmp;
            double.TryParse(textBox23.Text, out tmp);
            punkty3D[2].Y = (int)tmp;
            double.TryParse(textBox24.Text, out tmp);
            punkty3D[2].Z = (int)tmp;

            double.TryParse(textBox29.Text, out tmp);
            k = (int)tmp;

            punkty3D[3] = punkty3D[0];

            punkty3D[4].X = punkty3D[1].X - punkty3D[0].X;
            punkty3D[4].Y = punkty3D[1].Y - punkty3D[0].Y;
            punkty3D[4].Z = punkty3D[1].Z - punkty3D[0].Z;

            double nxb = 0.0, nxd = 0.0;
            nxb = (double)(punkty3D[2].X * punkty3D[3].X + punkty3D[2].Y * punkty3D[3].Y + punkty3D[2].Z * punkty3D[3].Z);
            nxd = (double)(punkty3D[2].X * punkty3D[4].X + punkty3D[2].Y * punkty3D[4].Y + punkty3D[2].Z * punkty3D[4].Z);

            if (nxd != 0)
            {
                mi = (k - nxb) / (nxd);

                textBox25.Text = mi.ToString();
                textBox26.Text = ((punkty3D[3].X + mi * punkty3D[4].X).ToString());
                textBox27.Text = ((punkty3D[3].Y + mi * punkty3D[4].Y).ToString());
                textBox28.Text = ((punkty3D[3].Z + mi * punkty3D[4].Z).ToString());


            }
            else
            {
                MessageBox.Show("n*d musi być różne 0");
            }

        }

        private void Count2_Click(object sender, EventArgs e)
        {
            Point3D[] punkty3D = new Point3D[6];
            double k, tmp;

            double.TryParse(textBox30.Text, out tmp);
            punkty3D[0].X = (int)tmp;
            double.TryParse(textBox31.Text, out tmp);
            punkty3D[0].Y = (int)tmp;
            double.TryParse(textBox32.Text, out tmp);
            punkty3D[0].Z = (int)tmp;

            double.TryParse(textBox33.Text, out tmp);
            punkty3D[1].X = (int)tmp;
            double.TryParse(textBox34.Text, out tmp);
            punkty3D[1].Y = (int)tmp;
            double.TryParse(textBox35.Text, out tmp);
            punkty3D[1].Z = (int)tmp;

            double.TryParse(textBox36.Text, out tmp);
            punkty3D[2].X = (int)tmp;
            double.TryParse(textBox37.Text, out tmp);
            punkty3D[2].Y = (int)tmp;
            double.TryParse(textBox38.Text, out tmp);
            punkty3D[2].Z = (int)tmp;

            punkty3D[3].X = punkty3D[1].X - punkty3D[0].X;
            punkty3D[3].Y = punkty3D[1].Y - punkty3D[0].Y;
            punkty3D[3].Z = punkty3D[1].Z - punkty3D[0].Z;

            punkty3D[4].X = punkty3D[2].X - punkty3D[0].X;
            punkty3D[4].Y = punkty3D[2].Y - punkty3D[0].Y;
            punkty3D[4].Z = punkty3D[2].Z - punkty3D[0].Z;

            punkty3D[5].X = punkty3D[3].Y * punkty3D[4].Z - punkty3D[3].Z * punkty3D[4].Y;
            punkty3D[5].Y = punkty3D[3].Z * punkty3D[4].X - punkty3D[3].Y * punkty3D[4].X;
            punkty3D[5].Z = punkty3D[3].X * punkty3D[4].Y - punkty3D[3].Y * punkty3D[4].X;

            textBox39.Text = (punkty3D[5].X).ToString();
            textBox40.Text = (punkty3D[5].Y).ToString();
            textBox41.Text = (punkty3D[5].Z).ToString();

            k = punkty3D[5].X * (-1) * punkty3D[0].X + punkty3D[5].Y * (-1) * punkty3D[0].Y + punkty3D[5].Z * (-1) * punkty3D[0].Z;
            textBox42.Text = (k).ToString();

        }
    }
}
