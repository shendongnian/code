    string projectFilePath = Path.Combine(@"c:\solutions\App\app.sln");
     
    ProjectCollection pc = new ProjectCollection();
     
    // THERE ARE A LOT OF PROPERTIES HERE, THESE MAP TO THE MSBUILD CLI PROPERTIES
    Dictionary<string, string> globalProperty = new Dictionary<string, string>();
    globalProperty.Add("OutputPath", @"c:\temp");
     
    BuildParameters bp = new BuildParameters(pc);
    BuildRequestData buildRequest = new BuildRequestData(projectFilePath, globalProperty, "4.0", new string[] { "Build" }, null);
    // THIS IS WHERE THE MAGIC HAPPENS - IN PROCESS MSBUILD
    BuildResult buildResult = BuildManager.DefaultBuildManager.Build(bp, buildRequest);
    // A SIMPLE WAY TO CHECK THE RESULT
    if (buildResult.OverallResult == BuildResultCode.Success)
    {              
        //...
    }
