    [EnableQuery]
    public IQueryable<ApiUserEntity> GetApiUsers()
    {
        return _userService.GetUsers();
    }
