    var screen = Screen.PrimaryScreen;
    using (var bitmap = new Bitmap(screen.Bounds.Width, screen.Bounds.Height))
    {
        using (var g = Graphics.FromImage(bitmap))
        {
            g.CopyFromScreen(screen.Bounds.Left, screen.Bounds.Top, 0, 0, screen.Bounds.Size);
        }
        var imageStream = new MemoryStream();
        bitmap.Save(imageStream, ImageFormat.Png);
        imageStream.Position = 0;
        return new Response()
        {
            Contents = stream => memoryStream.CopyTo(stream)
        };
    }
