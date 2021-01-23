    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace Blinker
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                timer1.Interval = 250;
                timer1.Tick += timer1_Tick;
                timer1.Start();
            }
    
            void timer1_Tick(object sender, EventArgs e)
            {
                Console.WriteLine("Tick");
                pictureBox1.BackColor = (pictureBox1.BackColor == System.Drawing.Color.Red) ? System.Drawing.Color.Black : System.Drawing.Color.Red;
            }
        }
    }
