    public static string ImagePathToBase64(string path)
    {
        using System.Drawing.Image image = System.Drawing.Image.FromFile(path);
        using MemoryStream m = new MemoryStream();
        image.Save(m, image.RawFormat);
        byte[] imageBytes = m.ToArray();
        tring base64String = Convert.ToBase64String(imageBytes);
        return base64String;
    }
