    using (SPSite site = new SPSite(SPContext.Current.Site.Url))
    {
        using (SPWeb web = site.RootWeb)
        {
            //...
        }
    }
