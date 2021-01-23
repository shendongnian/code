    public class CustomToolStripRenderer : ToolStripProfessionalRenderer
    {
        public CustomToolStripRenderer() { }
        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            //you may want to change this based on the toolstrip's dock or layout style
            LinearGradientMode mode = LinearGradientMode.Horizontal;
            using (LinearGradientBrush b = new LinearGradientBrush(e.AffectedBounds, ColorTable.MenuStripGradientBegin, ColorTable.MenuStripGradientEnd, mode))
            {
                e.Graphics.FillRectangle(b, e.AffectedBounds);
            }
        }
    }
