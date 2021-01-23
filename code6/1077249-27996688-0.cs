    private Image RotateImage(Bitmap bitmap)
    {
        PointF centerOld = new PointF((float)bitmap.Width / 2, (float)bitmap.Height / 2);
        Bitmap newBitmap = new Bitmap(bitmap.Width, bitmap.Height, bitmap.PixelFormat);
        // Make sure the two coordinate systems are the same
        newBitmap.SetResolution(bitmap.HorizontalResolution, bitmap.VerticalResolution);
        using (Graphics g = Graphics.FromImage(newBitmap))
        {
            Matrix matrix = new Matrix();
            // Rotate about old image center point
            matrix.RotateAt(45, centerOld);
            g.Transform = matrix;
            g.DrawImage(bitmap, new Point());
        }
        return newBitmap;
    }
