    //      aspectScale = when true, create an image that is up to the size (new w, new h)
    //                    that maintains original image aspect. When false, just create a
    //                    new image that is exactly the (new w, new h)
    private static Bitmap ReduceImageSize(Bitmap original, int newWidth, int newHeight, bool aspectScale)
    {
        if (original == null || (original.Width < newWidth && original.Height < newHeight)) return original;
        // calculate scale
        var scaleX = newWidth / (float)original.Width;
        var scaleY = newHeight / (float)original.Height;
        if (scaleY < scaleX) scaleX = scaleY;
        // calc new w/h
        var calcWidth = (aspectScale ? (int)Math.Floor(original.Width * scaleX) : newWidth);
        var calcHeight = (aspectScale ? (int)Math.Floor(original.Height * scaleX) : newHeight);
        var resultImg = new Bitmap(calcWidth, calcHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        using (var offsetMtx = new System.Drawing.Drawing2D.Matrix())
        {
            offsetMtx.Translate(calcWidth / 2.0f, calcHeight / 2.0f);
            offsetMtx.Scale(scaleX, scaleX);
            offsetMtx.Translate(-original.Width / 2.0f, -original.Height / 2.0f);
            using (var resultGraphics = System.Drawing.Graphics.FromImage(resultImg))
            {
                // scale
                resultGraphics.Transform = offsetMtx;
                // IMPORTANT: Compromise between quality and speed for these settings
                resultGraphics.SmoothingMode = SmoothingMode.HighQuality;
                resultGraphics.InterpolationMode = InterpolationMode.Bicubic;
                // For a white background add: resultGraphics.Clear(Color.White);
                // render the image
                resultGraphics.DrawImage(original, Point.Empty);
            }
        }
        return resultImg;
    }
