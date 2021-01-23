    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;
    using System.Text;
    using Rally.RestApi;
    using Rally.RestApi.Response;
    
    namespace FindTFchildren
    {
        class Program
        {
            static void Main(string[] args)
            {
                RallyRestApi restApi;
                restApi = new RallyRestApi("user@co.com", "secret", "https://rally1.rallydev.com", "v2.0");
    
                String projectRef = "/project/12352814790";     //replace this OID with an OID of your project
    
    
                Request fRequest = new Request("PortfolioItem/Feature");
                fRequest.Project = projectRef;
                fRequest.Workspace = workspaceRef;
                fRequest.Fetch = new List<string>() { "FormattedID", "Name", "UserStories"};
                fRequest.Query = new Query("FormattedID", Query.Operator.Equals, "F3");
                QueryResult queryResults = restApi.Query(fRequest);
    
                
                foreach (var f in queryResults.Results)
                {
                    Console.WriteLine("FormattedID: " + f["FormattedID"] + " Name: " + f["Name"]);
                    Console.WriteLine("Collection ref: " + f["UserStories"]._ref);
                    Request childrenRequest = new Request(f["UserStories"]);
                    QueryResult queryChildrenResult = restApi.Query(childrenRequest);
                    foreach (var c in queryChildrenResult.Results)
                    {
                        Console.WriteLine("FormattedID: " + c["FormattedID"] + " Name: " + c["Name"]);
                    }
    
                }
            }
        }
    }
