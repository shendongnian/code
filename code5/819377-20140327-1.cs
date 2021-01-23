    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace BigBrother
    {
        public class SizeablePictureBox : PictureBox
        {
    
            private const int grab = 16;
            public Point PBstartLocation;
            public Point PBcornerStart;
               
            public SizeablePictureBox()
            {
                this.ResizeRedraw = true;
            }
    
    
            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                var rc = new Rectangle(this.ClientSize.Width - grab, this.ClientSize.Height - grab, grab, grab);
                ControlPaint.DrawSizeGrip(e.Graphics, this.BackColor, rc);
            }
    
            protected override void WndProc(ref Message m)
            {
                base.WndProc(ref m);
                if (m.Msg == 0x84)
                {
    
                    var pos = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (pos.X >= this.ClientSize.Width - grab && pos.Y >= this.ClientSize.Height - grab)
                        m.Result = new IntPtr(17);
                }
            }
    
    
            protected override void OnMouseDown(MouseEventArgs e)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    PBstartLocation = e.Location;
                    PBcornerStart = this.Location;
                    this.BringToFront();
                }
    
            }
    
    
            protected override void OnMouseMove(MouseEventArgs e)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    this.Left = e.X + this.Left - PBstartLocation.X;
                    this.Top = e.Y + this.Top - PBstartLocation.Y;
                }
            }
        }
