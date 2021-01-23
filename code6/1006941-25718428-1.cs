    SPSite oSiteCollection = SPContext.Current.Site;
    using(SPWebCollection collWebs = oSiteCollection.AllWebs)
    {
    foreach (SPWeb oWebsite in collWebs)
    {
        SPListCollection collSiteLists = oWebsite.Lists;
        foreach (SPList oList in collSiteLists)
        {
            //get your each list here
        }
        oWebsite.Dispose();
    }
    }
