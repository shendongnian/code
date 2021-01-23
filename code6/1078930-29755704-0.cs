    Collection<SvnStatusEventArgs> filesStatuses = new Collection<SvnStatusEventArgs>();
    if (!client.GetStatus(localDir, new SvnStatusArgs
    {
        Depth = SvnDepth.Infinity,
        RetrieveRemoteStatus = true,
        RetrieveAllEntries = true
    }, out workDirFilesStatus))
    {
        throw new SvnOperationCanceledException("SvnClient.GetStatus doesn't return anything.");
    }
    
    filesStatuses.Where(i => i.LocalContentStatus == SvnStatus.NotVersioned).ToList().ForEach(i => svnC.Add(i.Path));
    filesStatuses.Where(i => i.LocalContentStatus == SvnStatus.Missing).ToList().ForEach(i => svnC.Delete(i.Path));
