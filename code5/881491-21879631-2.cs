    private static void Main(string[] args)
    {
        Uri collectionUri = new Uri("https://MyName.visualstudio.com/DefaultCollection");
    
        NetworkCredential credential = new NetworkCredential("USERNAME", "PASSWORD");
        TfsTeamProjectCollection teamProjectCollection = new TfsTeamProjectCollection(collectionUri, credential);
        teamProjectCollection.EnsureAuthenticated();
        WorkItemStore workItemStore = teamProjectCollection.GetService<WorkItemStore>();
        
        WorkItemCollection workItemCollection = workItemStore.Query("QUERY HERE");
    
        foreach (var item in workItemCollection)
        {
            //Do something here.
        }
    }
