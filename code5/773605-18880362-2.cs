    private byte[] BitmapSourceToByteArray(BitmapSource image)
    {
        using (var stream = new MemoryStream())
        {
            var encoder = new PngBitmapEncoder(); // or some other encoder
            encoder.Frames.Add(BitmapFrame.Create(image));
            encoder.Save(stream);
            return stream.ToArray();
        }
    }
