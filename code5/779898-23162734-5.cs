    public API.AccessBridgeVersionInfo VersionInfo
    {
        get { return GetVersionInfo(this.VmId); }
    }
    public API.AccessibleContextInfo Info
    {
        get { return GetContextInfo(this.VmId, this.Context); }
    }
    
    public Int64 Context
    {
        get;
        protected set;
    }
    
    public Int32 VmId
    {
        get;
        protected set;
    }
