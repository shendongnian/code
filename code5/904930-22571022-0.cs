    Bitmap bitmap = new Bitmap(120, 28);
    using (Graphics g = Graphics.FromImage(bitmap)) {
      VisualStyleRenderer renderer = 
        new VisualStyleRenderer(VisualStyleElement.Button.PushButton.Hot);
      renderer.DrawBackground(g, new Rectangle(0, 0, bitmap.Width, bitmap.Height));
    }
    bitmap.Save(@"...\button.png", ImageFormat.Png);
