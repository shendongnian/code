    string localPath = @"c:\ws\myfile.cs";
    TfsTeamProjectCollection tfs = new TfsTeamProjectCollection(new Uri(tfsServer));
    // Get a reference to Version Control.              
    _versionControl = tfs.GetService<VersionControlServer>();
    _workspace = _versionControl.TryGetWorkspace(localPath);
    if (_workspace == null)
    {
        throw new Exception("Workspace is not mapped");
    }
