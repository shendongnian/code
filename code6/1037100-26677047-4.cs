    public async Task<IQueryable<URL>> GetAllUrlsAsync()
    {
        var urls = await context.Urls.ToListAsync();
        return urls.AsQueryable();
    }
