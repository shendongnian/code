    public async void Method1()
    {
        var tuple = await GetDataTaskAsync();
        int op = tuple.Item1;
        int result = tuple.Item2;
    }
    
    public async Task<Tuple<int, int>> GetDataTaskAsync()
    {
        //...
        return new Tuple<int, int>(1, 2);
    }
