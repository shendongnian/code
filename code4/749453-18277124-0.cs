    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;
    using System.Text;
    using Rally.RestApi;
    using Rally.RestApi.Response;
    
    namespace Rest_v2._0_test
    {
        class Program
        {
            static void Main(string[] args)
            {
                //Initialize the REST API
                RallyRestApi restApi;
                restApi = new RallyRestApi("user@co.com", "secret", "https://rally1.rallydev.com", "v2.0");
    
                //get the current subscription
                DynamicJsonObject sub = restApi.GetSubscription("Workspaces");
    
                Request wRequest = new Request(sub["Workspaces"]);
    
                //query the Workspaces collection
                QueryResult queryResult = restApi.Query(wRequest);
    
               foreach (var result in queryResult.Results)
                {
                    var workspaceReference = result["_ref"];
                    var workspaceName = result["Name"];
                    Console.WriteLine( workspaceName + " " + workspaceReference);
                }
            }
        }
    }
