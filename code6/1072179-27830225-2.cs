    private bool IsUsernameAndPasswordValid(string username, string password)
    {
    	var index = GetUsernameIndex(username);
    	var storedPassword = GetPassword(index);
    	
    	//If storedPassword is empty, then return false
    	//If password and storedPassword do not match, then return false
        //Otherwise, the password is valid for this user
    	return storedPassword != string.Empty && password == storedPassword; 
    }
