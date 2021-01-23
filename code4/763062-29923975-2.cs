    using (var graphics = Graphics.FromImage(new Bitmap(1,1,PixelFormat.Format32bppArgb)))
    {
        var hdc = graphics.GetHdc();
        using (var original = new MemoryStream())
        {
            using (var dummy = Graphics.FromImage(new Metafile(original, hdc)))
            {
                dummy.DrawImage(emf, 0, 0, emf.Width, emf.Height);
                dummy.Flush();
            }
            graphics.ReleaseHdc(hdc);
            // do more stuff
        }
    }
