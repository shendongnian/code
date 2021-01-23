    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;
    using System.Text;
    using Rally.RestApi;
    using Rally.RestApi.Response;
    
    namespace aRESTremoveTagFromStory
    {
        class Program
        {
            static void Main(string[] args)
            {
                //Initialize the REST API
                RallyRestApi restApi;
                restApi = new RallyRestApi("user@co.com", "secret", "https://rally1.rallydev.com", "v2.0");
    
                //Set our Workspace and Project scopings
                String workspaceRef = "/workspace/1111"; //replace this OID with an OID of your workspace
                String projectRef = "/project/2222";     //replace this OID with an OID of your project
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
                         "Tags"
                    };
    
                storyRequest.Query = new Query("FormattedID", Query.Operator.Equals, "US123"); //replace this FormattedID with FormattedID valid in your workspace
                QueryResult queryStoryResults = restApi.Query(storyRequest);
    
               //create an array to contain modified list of tags for this story. 
                ArrayList tagList = new ArrayList();
    
                foreach (var s in queryStoryResults.Results)
                {
                   
                    Console.WriteLine("FormattedID: " + s["FormattedID"] + " Name: " + s["Name"]);
                    Console.WriteLine("----------");
    		///query for Tags collection on this story    
                    Request tagRequest = new Request(s["Tags"]);
                    QueryResult queryTagResult = restApi.Query(tagRequest);
                    int count = 0;
                    if (queryTagResult.TotalResultCount > 0)
                    {
                        foreach (var t in queryTagResult.Results)
                        {
                            var tagName = t["Name"];
                            var tagRef = t["_ref"];
                            Console.WriteLine(tagName + "  " + tagRef + " " + tagOID);
                            
                            if (count < queryTagResult.TotalResultCount - 1) //removes the last tag
                            {
                                DynamicJsonObject newTag = new DynamicJsonObject();
                                newTag["_ref"] = tagRef;
                                tagList.Add(newTag);
                            }
                            count++;
                        }
                    }
                    else
                    {
                        Console.WriteLine("no tags found");
                    }
    
                    DynamicJsonObject newTagCollection = new DynamicJsonObject();
                    newTagCollection["Tags"] = tagList;
    
                    OperationResult updateResult = restApi.Update(s["_ref"], newTagCollection);
                }
            }
        }
    }
