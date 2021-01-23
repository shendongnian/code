    public static string ToBase64(CookieContainer container)
    {
        string str = null;
        byte[] bytes = null;
        using (MemoryStream ms = new MemoryStream())
        {
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, container);
            bytes = ms.ToArray();
        }
        str = Convert.ToBase64String(bytes);
        return str;
    }
    public static CookieContainer FromBase64(string container_base64)
    {
        CookieContainer cc = null;
        byte[] bytes = Convert.FromBase64String(container_base64);
        using (MemoryStream ms = new MemoryStream(bytes))
        {
            BinaryFormatter bf = new BinaryFormatter();
            cc = (CookieContainer)bf.Deserialize(ms);
        }
        return cc;
    }
