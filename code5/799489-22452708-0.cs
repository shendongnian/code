    string url = "https://contoso.com:666/sites/SiteName/WebName";
    Guid listGuid = new Guid(...);        
    using(SPSite site = new SPSite(url))
    {
        using(SPWeb web = site.OpenWeb())
        {
          web.AllowUnsafeUpdates = true;
          SPList list = web.Lists[listGuid];
          list.Hidden = true;
          list.Update();
          web.AllowUnsafeUpadtes = false;
        }
    }
