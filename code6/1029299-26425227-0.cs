    public class LabelEx : System.Windows.Forms.Label
    {
        public LabelEx()
        {
            UseCompatibleTextRendering = true;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            // You can try this two options too.
            //e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            //e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            base.OnPaint(e);
        }
    }
