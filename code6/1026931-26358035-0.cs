    public Task<IQueryable<User>> GetUsersAsync
    {
        return Task.Run(() =>
        {
            return userManager.Users(); 
        }
    }
