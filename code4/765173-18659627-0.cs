            class Program
            {
                static void Main(string[] args)
                {
            
                    RallyRestApi restApi = new RallyRestApi("user@co.com", "secret", "https://rally1.rallydev.com", "v2.0");
                    String workspaceRef = "/workspace/1111";
                    String projectRef = "/project/2222";
            
                    Request dRequest = new Request("Defect");
                    dRequest.Workspace = workspaceRef;
                    dRequest.Project = projectRef;
            
                    dRequest.Fetch = new List<string>()
                        {
                            "Name",
                            "FormattedID",
                        };
            
                    var fid = "DE1";
            
                    dRequest.Query = new Query("FormattedID", Query.Operator.Equals, fid);
                    QueryResult queryResults = restApi.Query(dRequest);
                    DynamicJsonObject defect = queryResults.Results.First();
                    String defectRef = defect["_ref"];
                    Console.WriteLine(defectRef);
                    Console.WriteLine("FormattedID: " + defect["FormattedID"] + " Name: " + defect["Name"]);
    //...........
