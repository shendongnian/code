    static string ToBase64Url(string base64)
    {
        return base64.Replace("/", "_").Replace("+", "-");
    }
    static string FromBase64Url(string base64Url)
    {
        return base64Url.Replace("_", "/").Replace("-", "+");
    }
