    public static byte[] GetBytes(Image image)
    {
        byte[] byteArray = new byte[0];
        using (MemoryStream stream = new MemoryStream())
        {
            // you may want to choose another image format than PNG
            image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            stream.Close();
    
            byteArray = stream.ToArray();
        }
        return byteArray;
    }
