    public bool AuthenticateUser(string EmailAddress, string password,out string msg)
    {
        msg = string.Empty;
        if (password == null || password == string.Empty || EmailAddress == null || EmailAddress == string.Empty)
        {
            msg = "Email and/or password can't be empty!";
            return false;
        }
        
        try
        {
            ADUserInfo userInfo = GetUserAttributes(EmailAddress);
           
            if (userInfo == null)
            {
                msg = "Error: Couldn't fetch user information!";
                return false;
            }
            DirectoryEntry directoryEntry = new DirectoryEntry(LocalGCUri, userInfo.Upn, password);
            directoryEntry.AuthenticationType = AuthenticationTypes.None;
            string localFilter = string.Format(ADSearchFilter, EmailAddress);
            DirectorySearcher localSearcher = new DirectorySearcher(directoryEntry);
            localSearcher.PropertiesToLoad.Add("mail");
            localSearcher.Filter = localFilter;
            SearchResult result = localSearcher.FindOne();
            if (result != null)
            {
                msg = "You have logged in successfully!";
                return true;
            }
            else
            {
                msg = "Login failed, please try again.";
                return false;
            }
        }catch (Exception ex)
        {
            //System.ArgumentException argEx = new System.ArgumentException("Logon failure: unknown user name or bad password");
            //throw argEx;
            msg = "Wrong Email and/or Password!";
            return false;
        }
    }
