    private bool IsImageTooLarge(Image img, long maxSize)
    {
        using (var ps = new PositionNullStream()) {
            img.Save(ps, System.Drawing.Imaging.ImageFormat.Png);
            return ps.Position > maxSize;
        }
    }
