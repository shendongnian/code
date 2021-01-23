    public GetDataOperationResult<User> GetUser(Guid userId)
    {
        return DataManager.TryGet<User>(() => DataProvider.GetUser(userId), "The user was 
    loaded successfully", "There was a problem loading the user");
    }
