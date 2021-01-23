    var workspace=MSBuildWorkspace.Create();
    var solution = workspace.OpenSolutionAsync(solutionPath).Result;
    var projects = solution.Projects;
    foreach(var project in projects)
    {
      //TODO              
    }
