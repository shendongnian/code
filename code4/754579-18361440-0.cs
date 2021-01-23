    public static bool Login(string userName, string password, bool persistCookie = false)
    {
    	WebSecurity.VerifyProvider();
    	bool flag = Membership.ValidateUser(userName, password);
    	if (flag)
    	{
    		FormsAuthentication.SetAuthCookie(userName, persistCookie);
    	}
    	return flag;
    }
