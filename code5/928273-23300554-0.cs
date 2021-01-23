    public IAsyncOperation<string> SomeMethodAsync(int id)
    {
        var task = Task.Run<string>(async () =>
        {
            var idString = await GetMyStringAsync(id); 
            return idString;
        });
    
        return task.AsAsyncOperation();
    }
