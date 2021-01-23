    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                PictureBox pb = new PictureBox();
                pb.Size = new Size(200, 200);
                pb.BackColor = Color.Aqua;
                pb.Location=pb.FromCartesian(new Point(20, 20));
                Controls.Add(pb);
            }
        }
    
        public static class PictureBoxExtensions
        {
            public static Point ToCartesian(this PictureBox box, Point p)
            {
                return new Point(p.X, p.Y - box.Height);
            }
    
            public static Point FromCartesian(this PictureBox box, Point p)
            {
                return new Point(p.X, box.Height - p.Y);
            }
        }
    }
