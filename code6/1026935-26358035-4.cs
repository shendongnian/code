    public async Task<List<User>> GetUsersAsync()
    {
        using (var context = new YourContext())
        {
            return await context.Users.ToListAsync();
        }
    }
