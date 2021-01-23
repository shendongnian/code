    NameValueCollection queryCollection = HttpUtility.ParseQueryString(Request.Url.Query);
    var items = queryCollection
                     .AllKeys
                     .SelectMany(queryCollection.GetValues, (k, v) => new { key = k, value = v })
                     .Where(p => p.key.Contains("bSortable"))
                     .ToList();
