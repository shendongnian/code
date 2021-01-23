    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace WindowsFormsApplication4
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            bool isMouseDown;
            Point lastPoint = new Point(0,0);
            private void panel1_MouseDown(object sender, MouseEventArgs e)
            {
                isMouseDown = true;
                lastPoint = e.Location;
            }
            private void panel1_MouseMove(object sender, MouseEventArgs e)
            {
                if (isMouseDown)
                {
                    panel1.Location = new Point(
                        (
                        panel1.Location.X + e.X) - lastPoint.X,
                        (panel1.Location.Y + e.Y) - lastPoint.Y);
                    this.Update();
                }
            }
            private void panel1_MouseUp(object sender, MouseEventArgs e)
            {
                isMouseDown = false;
            }
        }
    }
