    // Get the workspace information for the build server's workspace
    var workspaceInfo = Workstation.Current.GetLocalWorkspaceInfo(sourcesDirectory);
    // Get the TFS Team Project Collection information from the workspace cache
    // information then load the TFS workspace itself.
    var server = new TfsTeamProjectCollection(workspaceInfo.serverUri);
    var workspace = workspaceInfo.GetWorkspace(server);
