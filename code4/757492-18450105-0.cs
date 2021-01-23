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
                String workspaceRef = "/workspace/1111"; //please replace this OID with an OID of your workspace 
                String projectRef = "/project/2222";     //please replace this OID with an OID of your project
                bool projectScopingUp = false;
                bool projectScopingDown = true;
    
                Request storyRequest = new Request("Defect");
    
    
                storyRequest.Workspace = workspaceRef;
                storyRequest.Project = projectRef;
                storyRequest.ProjectScopeUp = projectScopingUp;
                storyRequest.ProjectScopeDown = projectScopingDown;
    
                storyRequest.Fetch = new List<string>()
                    {
                        "Name",
                        "_ref",
                        "c_JiraLink"
                    };
    
                storyRequest.Query = new Query("FormattedID", Query.Operator.Equals, "DE170");       
                QueryResult queryStoryResults = restApi.Query(storyRequest);
    
                foreach (var s in queryStoryResults.Results)
                {
                   Console.WriteLine(" Name: " + s["Name"] + " JiraLink's DisplayString: " + s["c_JiraLink"]["DisplayString"] + " JiraLink's LinkID: " + s["c_JiraLink"]["LinkID"]);  
                   DynamicJsonObject toUpdate = new DynamicJsonObject();
                   DynamicJsonObject myLink = new DynamicJsonObject();
                   myLink["LinkID"] = "NM-3";
                   myLink["DisplayString"] = "";
                   toUpdate["c_JiraLink"] = myLink;
    
                   OperationResult updateResult = restApi.Update(s["_ref"], toUpdate);  
                }
            }
        }
    }
