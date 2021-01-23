    private bool SetCustomId(string username, Guid id)
    {
        using(new Sitecore.Security.Accounts.UserSwitcher(Sitecore.Security.Accounts.User.FromName(username,false));)
        {
            var userProfile = ((User)User.FromName(username, AccountType.User)).Profile;
            userProfile.SetCustomProperty("MyIdField", id.ToString());
            userProfile.Save();
        }
        
    }
