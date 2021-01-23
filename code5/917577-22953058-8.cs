    private MemoryStream MakeMetafileStream(Bitmap image)
    {
        Graphics graphics = null;
        Metafile metafile = null;
        var stream = new MemoryStream();
        try
        {
            using (graphics = Graphics.FromImage(image))
            {
                var hdc = graphics.GetHdc();
                metafile = new Metafile(stream, hdc);
                graphics.ReleaseHdc(hdc);
            }
            using (graphics = Graphics.FromImage(metafile))
            { graphics.DrawImage(image, 0, 0); }
        }
        finally
        {
            if (graphics != null)
            { graphics.Dispose(); }
            if (metafile != null)
            { metafile.Dispose(); }
        }
        return stream;
    }
