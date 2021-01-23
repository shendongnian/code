    public static string ModifyQueryString(this UrlHelper helper, NameValueCollection updates, IEnumerable<string> removes)
    {
        var request = helper.RequestContext.HttpContext.Request;
        var url = request.Url.AbsolutePath;
        var query = HttpUtility.ParseQueryString(request.QueryString.ToString());
        updates = updates ?? new NameValueCollection();
        foreach (string key in updates.Keys)
        {
            query.Set(key, updates[key]);
        }
        removes = removes ?? new List<string>();
        foreach (string param in removes)
        {
            query.Remove(param);
        }
        if (query.HasKeys())
        {
            return string.Format("{0}?{1}", url, query.ToString());
        }
        else
        {
            return url;
        }
    }
