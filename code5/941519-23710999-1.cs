    public static byte[] ToByteArray(this Image image)
    {
        var stream = new MemoryStream();
        image.Save(stream, ImageFormat.Png);
        return stream.ToArray();
    }
