    // at class level
    [System.Runtime.InteropServices.DllImport("gdi32.dll")]
    public static extern bool DeleteObject(IntPtr hObject);
----------
    if (Clipboard.ContainsImage())
    {
        IDataObject clipboardData = Clipboard.GetDataObject();
        if (clipboardData != null)
        {
            if (clipboardData.GetDataPresent(System.Windows.Forms.DataFormats.Bitmap))
            {
                System.Drawing.Bitmap bitmap = (System.Drawing.Bitmap)clipboardData.GetData(System.Windows.Forms.DataFormats.Bitmap);
                IntPtr hBitmap = bitmap.GetHbitmap();
                try
                {
                    ImageUIElement.Source = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(hBitmap, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                    Console.WriteLine("Clipboard copied to UIElement");
                }
                finally 
                {
                    DeleteObject(hBitmap)
                }
            }
        }
    }
