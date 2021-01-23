    public async Task DoAll(IDoSomething[] doers) {
        //using ToArray to materialize the query right here
        //so we don't accidentally run it twice later.
        var tasks = doers.Select(d => d.Do()).ToArray();
        await Task.WhenAll(tasks);
    }
