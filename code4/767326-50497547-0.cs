    public async void Method1()
    {
        (int op, int result) tuple = await GetDataTaskAsync();
        int op = tuple.op;
        int result = tuple.result;
    }
    
    public async Task<(int op, int result)> GetDataTaskAsync()
    {
        int x = 5;
        int y = 10;
        return (op: x, result: y):
    }
