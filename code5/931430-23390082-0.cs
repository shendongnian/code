    var tpc = new TfsTeamProjectCollection(new Uri("http://localhost:8080/tfs/DefaultCollection"));
    var vcs = tpc.GetService<VersionControlServer>();
    var result = vcs.TryGetWorkspace(@"C:\MySourceCode") ??
                    vcs.CreateWorkspace(new CreateWorkspaceParameters("MyWorkSpace")
    {
        Location = WorkspaceLocation.Local,
        Folders = new []
        {
            new WorkingFolder("$/", @"C:\MySourceCode", WorkingFolderType.Map, RecursionType.Full)
        }
    });
    result.Get(VersionSpec.Latest, GetOptions.GetAll);
