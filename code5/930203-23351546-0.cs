    internal Dictionary<string, string> GetIDsAndXPaths()
    {
        var web = new HtmlWeb();
        var webidsAndXPaths = new Dictionary<string, string>();
        var page = driver.PageSource; // Gets the source of the page last loaded by the browser
        var doc = web.Load(page);
        var nodes = doc.DocumentNode.SelectNodes("//*[@id]");
        if (nodes == null) return webidsAndXPaths;
        // more code to get ids and such
        return webidsAndXPaths;
    }
