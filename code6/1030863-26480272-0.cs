    ///Handles nested query folders    
    private static Guid FindQuery(QueryFolder folder, string queryName)
    {
        foreach (var item in folder)
        {
            if (item.Name.Equals(queryName, StringComparison.InvariantCultureIgnoreCase))
            {
                return item.Id;
            }
            var itemFolder = item as QueryFolder;
            if (itemFolder != null)
            {
                var result = FindQuery(itemFolder, queryName);
                if (!result.Equals(Guid.Empty))
                {
                    return result;
                }
            }
        }
        return Guid.Empty;
    }
    static void Main(string[] args)
    {
        var collectionUri = new Uri("http://TFS/tfs/DefaultCollection");
        var server = new TfsTeamProjectCollection(collectionUri);
        var workItemStore = server.GetService<WorkItemStore>();
    
        var teamProject = workItemStore.Projects["TeamProjectName"];
    
        var x = teamProject.QueryHierarchy;
        var queryId = FindQuery(x, "QueryNameHere");
            
        var queryDefinition = workItemStore.GetQueryDefinition(queryId);
        var variables = new Dictionary<string, string>() {{"project", "TeamProjectName"}};
    
        var result = workItemStore.Query(queryDefinition.QueryText,variables);
    }
