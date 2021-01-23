    public async void Method1()
    {
        // Version 1, named tuples:
        // just to show how it works
        var tuple = await GetDataTaskAsync();
        int op = tuple.paramOp;
        int result = tuple.paramResult;
        
        // Version 2, tuple deconstruction:
        // much shorter, most elegant
        (int op, int result) = await GetDataTaskAsync();
    }
    
    public async Task<(int paramOp, int paramResult)> GetDataTaskAsync()
    {
        //...
        return (1, 2);
    }
