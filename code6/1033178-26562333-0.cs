    public static bool HasLatestFiles(Workspace ws)
    {
        bool hasLatestFiles = true;
    
        var result = ws.Get(LatestVersionSpec.Instance, GetOptions.Preview);
        
        hasLatestFiles = result.NoActionsNeeded;
        return hasLatestFiles;
    }
