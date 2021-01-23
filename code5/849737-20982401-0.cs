    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace Test
    {
        public partial class Form1 : Form
        {
            bool mouseHover;
            int width;
            int height;
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                timer1.Interval = 25;
                timer1.Tick += timer1_Tick;
                width = pictureBox1.Width;
                height = pictureBox1.Height;
                timer1.Start();
            }
    
            void timer1_Tick(object sender, EventArgs e)
            {
                if (mouseHover)
                {
                    pictureBox1.Width += (pictureBox1.Width < 100) ? 5 : 0;
                    pictureBox1.Height += (pictureBox1.Height < 100) ? 5 : 0;
                }
                else
                {
                    pictureBox1.Width += (pictureBox1.Width > width) ? -5 : 0;
                    pictureBox1.Height += (pictureBox1.Height > height) ? -5 : 0;
                }
            }
    
            private void pictureBox1_MouseEnter(object sender, EventArgs e)
            {            
                mouseHover = true;
            }
    
            private void pictureBox1_MouseLeave(object sender, EventArgs e)
            {
                mouseHover = false;
            }
        }
    }
