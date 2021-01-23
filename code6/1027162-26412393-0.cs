    public Task<UserInfo> GetUserDataAsync(string NetworkID)
    {
        return Task.Run(() =>
        {
            PrincipalContext principalcontext = new PrincipalContext(ContextType.Domain, ADDomain, ADUser, ADPass);
            UserPrincipal = UserPrincipal.FindByIdentity(principalcontext, IdentityType.SamAccountName, NetworkID);
    
            return founduser != null && founduser.Enabled == true ?
              new UserInfo
              {
                DisplayName = founduser.DisplayName,
                Email = founduser.EmailAddress,
                NetworkID = founduser.SamAccountName
              } : new UserInfo();
        });
    }
