    public class RoundButton : Button
    {
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            var rect = e.ClipRectangle;
            System.Drawing.Drawing2D.GraphicsPath grPath = new System.Drawing.Drawing2D.GraphicsPath();
            //grPath.AddPie(new Rectangle(1, 1, 10, 10), 180, 18);
            grPath.AddPie(rect, 0, 360);
            this.Region = new System.Drawing.Region(grPath);
            base.OnPaint(e);
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            //Need to handle this more elegantly
            //base.OnMouseEnter(e);
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            //Need to handle this more elegantly
            //base.OnMouseLeave(e);
        }
    }
