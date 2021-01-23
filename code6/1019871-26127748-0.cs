    Rectangle bounds = Screen.PrimaryScreen.Bounds;
    Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height);
    using (Graphics graphics = Graphics.FromImage(bitmap))
    {
          graphics.CopyFromScreen(bounds.X, 0, bounds.Y, 0, bounds.Size);
    }
    using (MemoryStream stream = new MemoryStream())
    {
         bitmap.Save(stream, ImageFormat.Png);
    }
