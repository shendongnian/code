    public static string GetHashText(string txt)
    {
        byte[] tmpSource = new UTF8Encoding().GetBytes(txt);
        return Convert.ToBase64String(tmpSource);
    }
    public static string DecodeText(string txt)
    {
        byte[] tmpData = Convert.FromBase64String(txt);
        string tmp = new UTF8Encoding().GetString(tmpData);
        return tmp;
    }
