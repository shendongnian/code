    private string UrlToName(string url)
    {
        foreach (char c in System.IO.Path.GetInvalidFileNameChars())
        {
            url = url.Replace(c, '_');
        }
        return url;
    }
