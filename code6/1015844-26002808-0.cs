    public void MyServerHubMethod()
    {
        // The following line will throw an InvalidCastException since
        // Client methods cannot return values to the server.
        List<Site> sites = (List<Site>)Clients.Caller.GetSiteList();
        DoSomethingWithSites(sites);
    }
