    using System.Windows.Forms;
    public class FastImageRedraw : Panel
    {
        private Image image;
        public FastImageRedraw()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.UpdateStyles();
        }
        public Image Image
        {
            get { return this.image; }
            set 
            {
                this.image = value;
                this.Invalidate();
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawImage(this.Image, e.ClipRectangle);
        }
    }
