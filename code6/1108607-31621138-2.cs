    string ImageToBase64String(Image image)
    {
        using (MemoryStream stream = new MemoryStream())
        {
            image.Save(stream, image.RawFormat);
            return Convert.ToBase64String(stream.ToArray());
        }
    }
