    public class ImageControl : Control
    {
        [Description("The base image for this control to render.")]
        public Bitmap Image { get; set; }
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
 	        // base.OnPaintBackground(pevent);
        }
        
        /// <summary>
        /// Override paint so that it uses your glow regardless of when it is instructed to draw
        /// </summary>
        /// <param name="pevent"></param>
        protected override void OnPaint(PaintEventArgs pevent)
        {
            pevent.Graphics.DrawImage(Image, 0, 0, Width, Height);
            pevent.Graphics.DrawLine(Pens.Blue, 0, 0, 100, 100);
        }
    }
