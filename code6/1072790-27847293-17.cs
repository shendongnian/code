    private List<string> GetUrls(string html)
    {
        var urls = new List<string>();
        int ndx = html.IndexOf("\"ou\"", StringComparison.Ordinal);
        while (ndx >= 0)
        {
            ndx = html.IndexOf("\"", ndx + 4, StringComparison.Ordinal);
            ndx++;
            int ndx2 = html.IndexOf("\"", ndx, StringComparison.Ordinal);
            string url = html.Substring(ndx, ndx2 - ndx);
            urls.Add(url);
            ndx = html.IndexOf("\"ou\"", ndx2, StringComparison.Ordinal);
        }
        return urls;
    }
