    using Microsoft.TeamFoundation.Client;
    using Microsoft.TeamFoundation.VersionControl.Client;
     
    var workspace = Workstation.Current.GetLocalWorkspaceInfo(Directory.GetCurrentDirectory());
    if (workspace != null)
    {
      teamProjectUri = workspace.ServerUri;
     
      var server = TfsConfigurationServerFactory.GetConfigurationServer(teamProjectUri);
      var projectCollection = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(teamProjectUri)
       
      var cssService = projectCollection.GetService<ICommonStructureService4>();
      var project = cssService.GetProjectByName(ProjectName)
    }
