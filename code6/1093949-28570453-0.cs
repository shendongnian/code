    public async Task<Tuple<SaveStatus, int>> Save(Foo foo)
    {
        SaveStatus status;
        int param;
        
        // ... 
        
        return Tuple.Create(status, param);
    }
