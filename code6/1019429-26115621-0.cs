    using (var site = new SPSite(siteUrl))
    {
        using (var web = site.OpenWeb())
        {
            var currentUser = web.CurrentUser;
            //..
        }
    }
