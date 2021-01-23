    namespace aRESTcreateTags
    {
        class Program
        {
            static void Main(string[] args)
            {
                string tagName = "T3$T";
    
                RallyRestApi restApi = new RallyRestApi("user@co.com", "secret", "https://rally1.rallydev.com", "v2.0");
    
                //get current user
                DynamicJsonObject user = new DynamicJsonObject();
                user = restApi.GetCurrentUser();
                Console.Out.WriteLine("owner " + user["_ref"]);
    
    
                //find workspaces owned by this user
                //equivalent to this endpoint: https://rally1.rallydev.com/slm/webservice/v2.0/subscription/1154643/workspaces?query=(Owner%20=%20%22/user/12345%22)
     
                DynamicJsonObject sub = restApi.GetSubscription("Workspaces");
    
                Request wRequest = new Request(sub["Workspaces"]);
                wRequest.Query = new Query("Owner", Query.Operator.Equals, user["_ref"]);
                QueryResult wResult = restApi.Query(wRequest);
                foreach (var workspace in wResult.Results)
                {
                    //Console.Out.WriteLine(workspace["_refObjectName"] + " : " + workspace["_ref"]);
                    Request tagRequest = new Request("tag");
                    tagRequest.Query = new Query("Name", Query.Operator.Equals, tagName);
                    QueryResult tagResult = restApi.Query(tagRequest);
                    if (tagResult.TotalResultCount == 0)
                    {
                        Console.Out.WriteLine("TAG " + tagName + " not found, creating");
                        DynamicJsonObject newTag = new DynamicJsonObject();
                        newTag["Name"] = tagName;
                        newTag["Workspace"] = workspace["_ref"];
                        CreateResult createResult = restApi.Create("Tag", newTag);
                        Console.Out.WriteLine(createResult.Reference + " created in workspace " + workspace["_refObjectName"]);
                    }
                    else
                    {
                        Console.Out.WriteLine("TAG " + tagName + " found in " + workspace["_refObjectName"]);
                        Console.Out.WriteLine(tagResult.Results.First()["_refObjectName"] + " " + tagResult.Results.First()["_ref"]);
                    }
    
                }
    
            }
        }
    }
