    public static BitmapImage getImage(string img)
    {
        byte[] filebytes = Convert.FromBase64String(img);
        MemoryStream ms = new MemoryStream(filebytes, 0, filebytes.Length);
        BitmapImage image = new BitmapImage();
        image.SetSource(ms);
        return image;
    }
    Icon = getImage(query.Element("Icon").Value);
