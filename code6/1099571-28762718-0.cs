    [WebGet]
    public async Task<Guid> LongRunningProcess()
    {
        var taskId = new Guid();
        
        // IO bound operation
        var dbResult = await readFromDbAsync();
        // IO bound operation
        var dbResult = await readFromDbAsync();
        
        // CPU bound?
        generateReport(dbResult);
        // IO bound operation
        await sendNotification();
        return taskId;
    }
