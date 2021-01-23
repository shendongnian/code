    private async void ParseSite(Site s)
    {
        while (true)
        {
            await s.ParseData();
        }
    }
    public void ParseAll(List<Site> siteList)
    {
        foreach (var site in siteList)
        {
            ParseSite(site);
        }
    }
