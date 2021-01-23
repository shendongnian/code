    // Create a cropped `region` of the `original` Bitmap as a new bitmap,
    // preserving the original pixel format. If negative Width or Height are provided
    // for the clip region and `flipNegative` is set, the result is flipped accordingly.
    public Bitmap crop(Bitmap original, Rectangle region, bool flipNegative) {
        Rectangle bounds = new Rectangle(new Point(0, 0), original.Size);
        if (region.Width == 0 || region.Height == 0) { return null; }
        // Normalize width and height parameters, and track whether we might need to flip.
        bool flipHorizontal = region.Width < 0;
        bool flipVertical = region.Height < 0;
        if (flipHorizontal)
        {
            region.X += region.Width;
            region.Width = -region.Width;
        }
        if (flipVertical)
        {
            region.Y += region.Height;
            region.Height = -region.Height;
        }
        // Ensure we have a valid clipping rectangle, and make the GDI call.
        if (!region.IntersectsWith(bounds)) { return null; }
        region.Intersect(bounds);
        Bitmap result = original.Clone(region, original.PixelFormat);
        // Flip the result as appropriate.
        if (flipHorizontal && flipNegative)
        {
            result.RotateFlip(RotateFlipType.RotateNoneFlipX);
        }
        if (flipVertical && flipNegative)
        {
            result.RotateFlip(RotateFlipType.RotateNoneFlipY);
        }
        return result;
    }
