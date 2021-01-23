    public Task<bool> UpdateUsersAsync(ObservableCollection<User> updatedUsers, DatabaseServiceLocal dataService)
    {
    	var tcs = new TaskCompletionSource<bool>();
    	
    	BusyIndicator = true;
        BusyMessage = "Saving...";
    	
    	dataService.UpdateStaffAndUsersCompleted += (s, e) =>
                    {
                        BusyIndicator = false;
    					tcs.SetResult(e.Success);                 
                     };
         
        dataService.UpdateUsers(Database.CurrentProject.ProjectID, Database.CurrentClient.ClientID, updatedUsers, _DeletedProjectUsers);
    			
    	return tcs.Task;
    }
