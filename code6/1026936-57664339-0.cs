    public async Task<List<IdentityUser>> GetUsersAsync()
    {
        using (var context = new ApplicationDbContext())
        {
            return await context.Users.ToListAsync();
        }
    }
