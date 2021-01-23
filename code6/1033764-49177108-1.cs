    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;
    
    public class stickFace : Form
    {
         public stickFace()
        {
            new stickBody(this);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics draw = e.Graphics;
            Pen black = new Pen(Color.Black, 3);
            draw.DrawEllipse(black, 20, 20, 100, 100);
            base.OnPaint(e);
        }
    }
