    private async void SaveUsers(bool CloseForm)
    {
    	ObservableCollection<User> _UpdatedUsers = new ObservableCollection<User>(); 
    	DatabaseServiceLocal _dataService = new DatabaseServiceLocal(Database);
    	Dictionary<Task<bool>, User> tasks = new Dictionary<Task<bool>, User>();
    	
    	// start all tasks in parallel
    	foreach (UserViewModel _User in _AllUsers)
    	{
    	    if (_User.Dirty && !_User.IsBlank)
    		{ 
    			tasks.Add(IsUserUniqueAsync(_User, _dataService), _User);		
    		}
    	}			
    	 
    	// process each task as it completes
    	while(tasks.Count() > 0 )
    	{
    		var task = await Task.WhenAny(tasks.Keys.ToArray());
    		
    		if(task.Result)
    		{
    		    _UpdatedUsers.Add(_User.SaveAsUser()); 
    	    }
    	    else
    	    {
    		   MessageBox.Show(string.Format("Username {0} is not allowed as it already exists in the system. Please choose a different username.", ""), null);
    		   return;
    	    }
    		
    		tasks.Remove(task);
    	}
    			
        if( await UpdateUsersAsync(_UpdatedUsers, _dataService))
    	{
    		if (CloseForm)
    			ReturnToHomePage();
    		else
    		{
    	
    			LoadUsers();
    			OnUsersSaved();
    		}
    	}
    }
