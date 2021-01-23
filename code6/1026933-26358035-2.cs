    public async Task<IQueryable<User>> GetUsersAsync
    {
        return await Task.Run(() =>
        {
            return userManager.Users(); 
        }
    }
