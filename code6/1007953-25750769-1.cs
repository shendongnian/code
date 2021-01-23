    if (Clipboard.ContainsImage())
    {
        // ImageUIElement.Source = Clipboard.GetImage(); // does not work
        System.Windows.Forms.IDataObject clipboardData = System.Windows.Forms.Clipboard.GetDataObject();
        if (clipboardData != null)
        {
            if (clipboardData.GetDataPresent(System.Windows.Forms.DataFormats.Bitmap))
            {
                System.Drawing.Bitmap bitmap = (System.Drawing.Bitmap)clipboardData.GetData(System.Windows.Forms.DataFormats.Bitmap);
                ImageUIElement.Source =  System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(bitmap.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty,BitmapSizeOptions.FromEmptyOptions());
                Console.WriteLine("Clipboard copied to UIElement");
            }
        }
    }
