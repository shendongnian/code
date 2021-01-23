    private static Dictionary<string, object> FromCookies(HttpCookieCollection cc)
    {
        var result = cc.AllKeys
            .Select(cookie => new { Name = cookie, Value = (object)cc[cookie] })
            .GroupBy(x => x.Name, StringComparer.InvariantCultureIgnoreCase)
            .ToDictionary(g => g.Key, g => g.First().Value, StringComparer.InvariantCultureIgnoreCase);
        return result;
    }
