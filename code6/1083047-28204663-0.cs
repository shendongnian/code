    public string GetSortedQueryString(string url)
    {
        var queryString = HttpUtility.ParseQueryString(url);
        // Ignore null keys (caused by your ?& at the start of the query string
        var orderedKeys = queryString.Cast<string>().Where(k => k != null).OrderBy(k => k);
        return string.Join("&", orderedKeys.Select(k => string.Format("{0}={1}", k, queryString[k])));
    }
