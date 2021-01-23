    public string GetBase64(Image image)
    {
        byte[] bytearray;
        using (MemoryStream ms = new MemoryStream())
        {
            WriteableBitmap wb = new WriteableBitmap((BitmapImage)image.Source);
            wb.SaveJpeg(ms, wb.PixelWidth, wb.PixelHeight, 0, 100);
            bytearray = ms.ToArray();
        }
        return Convert.ToBase64String(bytearray);
    }
