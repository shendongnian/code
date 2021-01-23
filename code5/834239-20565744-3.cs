    var workspace = Workstation.Current.GetLocalWorkspaceInfo(solutionFolder);
    if (workspace != null)
    {
        var teamProjectUri = workspace.ServerUri;
 
        // var server = TfsConfigurationServerFactory.GetConfigurationServer(teamProjectUri);
        var projectCollection = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(teamProjectUri);   
        var cssService = projectCollection.GetService<ICommonStructureService4>();
        var project = cssService.GetProjectFromName(solutionName);
    }
