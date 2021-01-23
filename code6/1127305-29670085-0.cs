    async Task<Result> Function1()
    {
        var resp = await requestHttp.BeginGetRequestStream();
        return Function2(resp);
    }
    
    async Task<Result> Function2(Response response)
    {
        var resp2 = await xxxxx();
        return Function3(resp2);
    }
    
    async Task<Result> Function(Type2 response)
    {
        await xxxxx();
        //calculation
        return Result;
    }
