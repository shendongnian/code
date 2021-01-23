    public Image ConvertByteArrayToImage(byte[] bytes)
    {
        System.IO.MemoryStream stream = new System.IO.MemoryStream(bytes);
        return Image.FromStream(stream);
    }
