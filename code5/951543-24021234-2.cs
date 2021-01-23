    public static System.Windows.Media.ImageSource ToImageSource(this System.Drawing.Bitmap bitmap, int width, int height)
    {
        var hBitmap = bitmap.GetHbitmap();
        System.Windows.Media.ImageSource wpfBitmap = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
            hBitmap,
            IntPtr.Zero,
            System.Windows.Int32Rect.Empty,
            System.Windows.Media.Imaging.BitmapSizeOptions.FromWidthAndHeight(width, height));
        if (!DeleteObject(hBitmap))
        {
            throw new System.ComponentModel.Win32Exception();
        }
        return wpfBitmap;
    }
