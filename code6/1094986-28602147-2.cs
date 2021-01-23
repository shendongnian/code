    public async Task<string> FirstOrDefaultAsync()
    {
        var list = await GetListAsync();
        return list.FirstOrDefault();
    }
