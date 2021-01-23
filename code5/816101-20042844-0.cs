    public IEnumerable<string> MapWorkspace(string path)
    {
        try
        {
            versionControl = tpc.GetService<VersionControlServer>();
            Workspace[] retVal = versionControl.QueryWorkspaces(null, "username", "computername");
            foreach (Workspace w in retVal)
            {
                yield return w.Name;
            }
            //var workspace = versionControl.GetWorkspace(path);  
        }
        catch (Exception exception)
        {
            Log.Write("Failed to map workspace! Exeption: " + exception.ToString());
        }
        return null;
    }
