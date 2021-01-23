    public static BitmapImage ConvertToBitmapImage(byte[] image)
    {
        WriteableBitmap wb = null;
        using (MemoryStream ms = new MemoryStream(image))
        {
            try
            {
                wb = Microsoft.Phone.PictureDecoder.DecodeJpeg(ms);
            }
            catch (Exception ex)
            {
                string error_message = ex.Message;
            }
        }
        return ConvertWBtoBI(wb);
    }
    // converts a WriteableBitmap to a BitmapImage
    private BitmapImage ConvertWBtoBI(WriteableBitmap wb)
    {
        if(wb == null)
           return null;
        BitmapImage bi;
        using (MemoryStream ms = new MemoryStream())
        {
            wb.SaveJpeg(ms, wb.PixelWidth, wb.PixelHeight, 0, 100);
            bi = new BitmapImage();
            bi.SetSource(ms);
        }
        return bi;
    }
