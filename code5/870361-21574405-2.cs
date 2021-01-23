    var CookieQuery = (from c in globals.AuthCookieContainer
                       where c.Name == "ss-id"
                       where !c.Expired
                       select c);
    if (CookieQuery.Count() > 0)
    {
        _ServiceClient.CookieContainer.Add(CookieQuery.FirstOrDefault());
    }
