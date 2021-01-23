    private void panel3_Paint(object sender, PaintEventArgs e)
    {
        e.Graphics.Clear(Color.White);
        e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
        Rectangle linearGradientregion = new Rectangle(10, 10, 95, 95);
        Rectangle pathRegion = new Rectangle(15, 15, 140, 140);
        int centerX = pathRegion.X + pathRegion.Width / 2;
        int centerY = pathRegion.Y + pathRegion.Height / 2;
        GraphicsPath path = new GraphicsPath();
        path.AddEllipse(pathRegion);
        LinearGradientBrush linearGradientBrush = 
            new LinearGradientBrush(linearGradientregion, Color.Red, Color.Yellow, 45);
        e.Graphics.FillPath(linearGradientBrush, path);
        e.Graphics.SetClip(path);
        e.Graphics.TranslateTransform(centerX, centerY);
        e.Graphics.RotateTransform(45f);
        e.Graphics.FillRectangle(Brushes.Green, 25, -90, 240, 240);
        e.Graphics.ResetTransform();
    }
