    public AboutInfo GetAboutInfo()
    {
     AboutInfo aboutInfo = new AboutInfo();
     SiteInfo siteInfo = new SiteInfo()
     {
        ID                = site.ID
       ,Name              = site.Name
       ,DatabaseVersion   = "Unavailable"
     };
		
	  var tasks = new List<Task<SiteInfo>>();
     foreach (Site site in sites)
     {
       try
       {
         string uri = Utilities.CombineUri(site.Uri, "svc/About.svc/ws");
         AboutServiceClient wcfClient = new AboutServiceClient("About");
         wcfClient.Endpoint.Address   = new EndpointAddress(uri);
		  tasks.Add(Task<SiteInfo>.Factory.FromAsync(wcfClient.GetSiteInfoBegin, wcfClient.EndSiteInfoBegin, null)
           .ContinueWith(t =>
           {                    
         		siteInfo.DatabaseVersion = t.Result.DatabaseVersion.DatabaseVersion;
           }, TaskScheduler.FromCurrentSynchronizationContext()));
         
       }
       catch (Exception e)
       { //...code stripped out... 
		}
	}
	Task.WhenAll(tasks.ToArray()).ContinueWith
		( ts =>
		{
			ts.ForEach( t => aboutInfo.Sites.Add(t.Rrsult); 
		});
		
	return aboutInfo;	
