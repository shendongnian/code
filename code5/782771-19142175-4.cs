    public async Task Hello()
    {
        var j = await GetJasonAsync();
        var tasks = new[] { GetJasonAsync(), GetMikeAsync(), GetMitchAsync() };
        string[] dankeSchon = await Task.WhenAll(tasks.Order());
    }
