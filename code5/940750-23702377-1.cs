    public static Bitmap XmlToBitmap(XElement xmlData)
    {
        string imageAsBase64String = xmlData.Attribute("PixelData").Value;
        byte[] imageAsBytes = Convert.FromBase64String(val);
        Bitmap result;
        using (MemoryStream imageAsMemoryStream = new MemoryStream(bytes))
        {
            result = new Bitmap(imageAsMemoryStream);
        }
    
        return result;
    }
