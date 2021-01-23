    private static String EncodeUrlInKey(String url)
    {
        var keyBytes = System.Text.Encoding.UTF8.GetBytes(url);
        var base64 = System.Convert.ToBase64String(keyBytes);
        return base64.Replace('/','_');
    }
