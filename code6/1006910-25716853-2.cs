    private string UrlToName(string url)
    {
        url = url + "_" + DateTime.Now.ToString("o");
        foreach (char c in System.IO.Path.GetInvalidFileNameChars())
        {
            url = url.Replace(c, '_');
        }
        return url;
    }
