    public async Task<List<User>> GetUsersAsync()
    {
        using (var context = new YourContext())
        {
            return await UserManager.Users.ToListAsync();
        }
    }
