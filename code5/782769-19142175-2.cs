    public async Task Hello()
    {
        var j = await GetJasonAsync();
        var task = Task.WhenAll(new Task<string>[] { GetJasonAsync(), GetMikeAsync(), GetMitchAsync() });
        try
        {
            string[] dankeSchon = await task;
        }
        catch (Exception)
        {
            throw task.Exception;
        }
    }
