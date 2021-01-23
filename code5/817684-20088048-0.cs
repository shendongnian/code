    public VersionControlServer VersionControl
    {
        get 
        {
            if (versionControl == null)
            {
                this.versionControl = this.tpc.GetService<VersionControlServer>();
            }
            return this.versionControl; 
        }   
    }
