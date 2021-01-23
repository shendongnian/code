    public static IReadOnlyDictionary<string, string> UnvalidatedParams(this HttpRequestBase request)
    {
        var dict = new Dictionary<string, string>();
        var unvalidated = request.Unvalidated;
        for (var i = 0; i < unvalidated.QueryString.Count; i++)
        {
            var name = unvalidated.QueryString.GetKey(i);
            if (string.IsNullOrWhiteSpace(name))
                continue;
            var value = unvalidated.QueryString.Get(i);
            dict[name] = value;
        }
        for (var i = 0; i < unvalidated.Form.Count; i++)
        {
            var name = unvalidated.Form.GetKey(i);
            if (string.IsNullOrWhiteSpace(name))
                continue;
            var value = unvalidated.Form.Get(i);
            dict[name] = value;
        }
        var cookieCount = unvalidated.Cookies.Count;
        for (var i = 0; i < cookieCount; i++)
        {
            var cookie = unvalidated.Cookies[i];
            if (string.IsNullOrWhiteSpace(cookie?.Name))
                continue;
            dict[cookie.Name] = cookie.Value;
        }
        for (var i = 0; i < request.ServerVariables.Count; i++)
        {
            var name = request.ServerVariables.GetKey(i);
            if (string.IsNullOrWhiteSpace(name))
                continue;
            var value = request.ServerVariables.Get(i);
            dict[name] = value;
        }
        return dict;
    }
