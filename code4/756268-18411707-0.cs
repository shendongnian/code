    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;
    using System.Text;
    using Rally.RestApi;
    using Rally.RestApi.Response;
    
    namespace aRestApp_CollectionOfTasks
    {
        class Program
        {
            static void Main(string[] args)
            {
                //Initialize the REST API
                RallyRestApi restApi;
                restApi = new RallyRestApi("user@co.com", "secret", "https://rally1.rallydev.com", "v2.0");
    
                //Set our Workspace and Project scopings
                String workspaceRef = "/workspace/11111"; //please replace this OID with an OID of your workspace
                String projectRef = "/project/22222";     //please replace this OID with an OID of your project
                bool projectScopingUp = false;
                bool projectScopingDown = true;
    
                Request storyRequest = new Request("HierarchicalRequirement");
    
    
                storyRequest.Workspace = workspaceRef;
                storyRequest.Project = projectRef;
                storyRequest.ProjectScopeUp = projectScopingUp;
                storyRequest.ProjectScopeDown = projectScopingDown;
    
                storyRequest.Fetch = new List<string>()
                    {
                        "Name",
    		            "FormattedID",
                        "Tasks",
                        "Estimate"
    
           
                    };
                storyRequest.Query = new Query("LastUpdateDate", Query.Operator.GreaterThan, "2013-08-01");      
                QueryResult queryStoryResults = restApi.Query(storyRequest);
    
                foreach (var s in queryStoryResults.Results)
                {
                    Console.WriteLine("----------");
                    Console.WriteLine("FormattedID: " + s["FormattedID"] + " Name: " + s["Name"]);
                    //Console.WriteLine("Tasks ref: " + s["Tasks"]._ref);
                    Request taskRequest = new Request(s["Tasks"]);
                    QueryResult queryTaskResult = restApi.Query(taskRequest);
                    if (queryTaskResult.TotalResultCount > 0)
                    {
                        foreach (var t in queryTaskResult.Results)
                        {
                            var taskEstimate = t["Estimate"];
                            var taskName = t["Name"];
                            Console.WriteLine("Task Name: " + taskName + " Estimate: " + taskEstimate);
                        }
                    }
                    else
                    {
                        Console.WriteLine("no tasks found");
                    }
                }
            }
        }
    }
