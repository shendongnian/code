    public byte[] ImageSourceToBytes(BitmapEncoder encoder, ImageSource imageSource)
    {
        byte[] bytes = null;
        var bitmapSource = imageSource as BitmapSource;
        if (bitmapSource != null)
        {
            encoder.Frames.Add(BitmapFrame.Create(bitmapSource));
            using (var stream = new MemoryStream())
            {
                encoder.Save(stream);
                bytes = stream.ToArray();
            }
        }
        return bytes;
    }
