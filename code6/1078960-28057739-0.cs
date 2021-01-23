    public string GetRequestHeaders()
    {
        HttpContext ctx = HttpContext.Current;
        if (ctx == null || ctx.Request == null || ctx.Request.Headers == null)
        {
            return string.Empty;
        }
        string headers = string.Empty;
        foreach (string header in ctx.Request.Headers.AllKeys)
        {
            string[] values = ctx.Request.Headers.GetValues(header);
            headers += string.Format("{0}: {1}", header, string.Join(",", values));
        }
        return headers;
    }
