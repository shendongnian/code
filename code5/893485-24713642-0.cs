    using SharpSvn;
    private static long GetRevision() 
    {
        using (SvnClient client = new SvnClient())
        {
            SvnInfoEventArgs info;
            return client.GetInfo(SvnPathTarget.FromString(REPO_PATH), out info) ? info.Revision : 0;
        }
    }
