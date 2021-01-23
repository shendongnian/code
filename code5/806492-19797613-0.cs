    [WebMethod]
    public static string GetImageArray()
    {
        return Convert.ToBase64String(File.ReadAllBytes(path.jpg));
    }
