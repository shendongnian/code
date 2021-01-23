    public static bool MyLogin(string userName, string password, bool persistCookie = false)
    {
    	bool flag = CheckADUser(userName, password);
    	
    	if (flag)
    	{
    		string mappedUsername = GetMappedUser(userName);
    		if(mappedUsername != "")
    		{
    			FormsAuthentication.SetAuthCookie(userName, persistCookie);
    		}
    		else
    		{
    			flag = false;
    		}
    	}
    	return flag;
    }
