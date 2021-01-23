    public async Task DoSomething()
    {
        IEnumerable<Task> tds = SearchProcess();
        await Task.WhenAll(tds);
        //continue processing    
    }
