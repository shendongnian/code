    private Bitmap rotateImage(Bitmap b, float angle)
    {
        using (var returnBitmap = new Bitmap(b.Width, b.Height,System.Drawing.Imaging.PixelFormat.Format32bppArgb))
        {
            using (var g = Graphics.FromImage(returnBitmap))
            {
                g.TranslateTransform((float)b.Width / 2, (float)b.Height / 2);
                g.RotateTransform((int)angle);
                g.TranslateTransform(-(float)b.Width / 2, -(float)b.Height / 2);
                b = (Bitmap)b.GetThumbnailImage(b.Width, b.Height, null, IntPtr.Zero);
                g.DrawImage(b, new Point(0, 0)); // Is the error still present?
                return returnBitmap;
            }
        }
    }
