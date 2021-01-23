    Dictionary params = new Dictionary<string,string>();
    foreach (string key in Request.QueryString)
    {
        var value = Request.QueryString[key];
        //
        //Do everything you need with params
        //
        params.Add(key, value);
    }
    Response.Redirect("{newUrl}?" + string.Join("&", params.Select(x=>string.Format("{0}={1}", x.Key, x.Value))));
