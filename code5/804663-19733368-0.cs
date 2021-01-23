    public static System.Windows.Media.Brush CreateBrushFromBitmap(Bitmap bmp)
    {
         IntPtr hBitMap = bmp.GetHbitmap();
         ImageBrush b = new ImageBrush(Imaging.CreateBitmapSourceFromHBitmap(hBitMap, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions()));
         DeleteObject(hBitMap);
         return b;
    }
