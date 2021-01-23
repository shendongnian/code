    public Task<List<User>> GetUsersAsync()
    {
        using (var context = new YourContext())
        {
            return context.Users.ToListAsync();
        }
    }
