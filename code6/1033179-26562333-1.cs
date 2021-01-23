    public static bool HasLatestFiles(Workspace ws)
    {
        GetStatus result = ws.Get(LatestVersionSpec.Instance, GetOptions.Preview);
        
        bool hasLatestFiles = result.NoActionNeeded;
        return hasLatestFiles;
    }
