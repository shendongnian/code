    public class Target : PictureBox
    {
        public Target()
        {
            this.Size = new Size(100, 100);
            this.Paint += Target_Paint;
            Rectangle rc = this.ClientRectangle;
            rc.Inflate(-10, -10);
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(rc);
            this.Region = new Region(gp);
        }
        void Target_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rc = this.ClientRectangle;
            rc.Inflate(-10, -10);
            using (Pen pen = new Pen(Color.Blue, 5))
            {
                e.Graphics.DrawEllipse(pen, rc);
            }
            rc = new Rectangle(new Point(this.Size.Width / 2, this.Size.Height / 2), new Size(1, 1));
            rc.Inflate(9, 9);
            e.Graphics.FillEllipse(Brushes.Red, rc);
        }
    }
