    private void panel1_Paint(object sender, PaintEventArgs e)
    {
        Rectangle bounds = panel1.ClientRectangle;
        using (var ellipsePath = new GraphicsPath())
        {
            ellipsePath.AddEllipse(bounds);
            using (var brush = new PathGradientBrush(ellipsePath))
            {
                // set the highlight point:
                brush.CenterPoint = new PointF(bounds.Width/3f, bounds.Height/4f);
                ColorBlend cb = new ColorBlend(4);
                cb.Colors = new Color[] 
                   {  Color.DarkRed, Color.Firebrick, Color.IndianRed, Color.PeachPuff };
                cb.Positions = new float[] { 0f, 0.3f, 0.6f, 1f };
                brush.InterpolationColors = cb;
                brush.FocusScales = new PointF(0, 0);
                e.Graphics.FillRectangle(brush, bounds);
            }
        }
        
    }
