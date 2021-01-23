    private void panel1_Paint(object sender, PaintEventArgs e)
    {
        e.Graphics.Clear(Color.White);
        e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
        Rectangle linearGradientregion = new Rectangle(10, 10, 150, 150);
        Rectangle pathRegion = new Rectangle(15, 15, 140, 140);
        GraphicsPath path = new GraphicsPath();
        path.AddEllipse(pathRegion);
        LinearGradientBrush linearGradientBrush = 
           new LinearGradientBrush(linearGradientregion, Color.Red, Color.Yellow, 45);
        ColorBlend cblend = new ColorBlend(4);
        cblend.Colors = new Color[4]  { Color.Red, Color.Yellow, Color.Green, Color.Green };
        cblend.Positions = new float[4] { 0f, 0.65f, 0.65f, 1f };
        linearGradientBrush.InterpolationColors = cblend;
        e.Graphics.FillPath(linearGradientBrush, path);
    }
