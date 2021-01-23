    private Task<bool> IsUserUniqueAsync(UserViewModel user, DatabaseServiceLocal dataService)
    {
    	var tcs = new TaskCompletionSource<bool>();
    	
    	dataService.CheckIsUserNameUnique += (s, e) =>
                            {
    							tcs.SetResult(e.IsUnique);
                            };
        dataService.IsUserNameUnique(user.UserName, user.UserID, Database.CurrentClient.ClientID);
    	return tcs.Task;
    }
