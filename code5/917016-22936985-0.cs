    using (Graphics graphic = panel1.CreateGraphics())
    {
      using (Image image = Image.FromFile(@"D:\tp3.png")) graphic.DrawImage(image, Point.Empty);
      using (Image image = Image.FromFile(@"D:\tp2.png")) graphic.DrawImage(image, Point.Empty);
      using (Image image = Image.FromFile(@"D:\tp1.png")) graphic.DrawImage(image, Point.Empty);
    }
