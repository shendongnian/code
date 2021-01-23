    private Bitmap BitmapImageToBitmap(BitmapImage bitmapImage)
    {
        using (MemoryStream os = new MemoryStream())
        {
            BitmapEncoder encoder = new BmpBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
            encoder.Save(os);
            System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(os);
            return new Bitmap(bitmap);
        }
    }
