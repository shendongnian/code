    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            static readonly Bitmap image = Properties.Resources.gecco_quad_dunkel;
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void panel1_Paint(object sender, PaintEventArgs e)
            {
                // using my own margin
                const int margin = 20;
    
                var dest = new Rectangle(
                    e.ClipRectangle.X + margin, 
                    e.ClipRectangle.Y + margin, 
                    e.ClipRectangle.Width - 2 * margin, 
                    e.ClipRectangle.Height - 2 * margin
                    );
    
                e.Graphics.DrawImage(image, dest);
            }
    
            private void panel2_Paint(object sender, PaintEventArgs e)
            {
                // using the margin information of the System.Windows.Forms.Control/Form
    
                var co = (Control)sender;
                var dest = new Rectangle(
                    e.ClipRectangle.X + co.Margin.Left, 
                    e.ClipRectangle.Y + co.Margin.Top, 
                    e.ClipRectangle.Width - co.Margin.Left - co.Margin.Right, 
                    e.ClipRectangle.Height - co.Margin.Top - co.Margin.Bottom
                    );
    
                e.Graphics.DrawImage(image, dest);
            }
        }
    }
