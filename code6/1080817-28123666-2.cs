    public static byte[] ImageToByteArray(Image image)
    {
        ImageConverter myConverter = new ImageConverter();
        return (byte[])myConverter.ConvertTo(image typeof(byte[]));
    }
