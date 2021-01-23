    private void RefreshData()
    {
        this.Clear();
        this.AddRange(GetData());
    }
    
    protected DataCacheMember(string apiEndPoint)
    {
        this.Clear();
        this.AddRange(GetData());
    }
