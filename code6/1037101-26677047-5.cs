    using System.Data.Entity;
    public IQueryable<URL> GetAllUrls()
    {
       return context.Urls.AsQueryable();
    }
    public async Task<List<URL>> GetAllUrlsByUser(int userId) {
       return await GetAllUrls().Where(u => u.User.Id == userId).ToListAsync();
    }
