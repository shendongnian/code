        private static bool UserHasPermisions(string userAccount, List<string> list)
        {
            bool userHasPermisions = true; 
            if (list != null && list.Count > 0)
            {
                userHasPermisions = false;
                foreach (string item in list)
                {
                    if (CheckGroupMembership(userAccount, item, "domain.local goes here..."))
                    {
                        userHasPermisions = true;
                    }
                }
            }
            return userHasPermisions;
        }
    public static bool CheckGroupMembership(string userID, string groupName, string domain)
        {
            bool isMember = false;
            try
            {
                PrincipalContext ADDomain = GetPrincipalContext();
                UserPrincipal oUserPrincipal = UserPrincipal.FindByIdentity(ADDomain, userID);
                PrincipalSearchResult<Principal> oPrincipalSearchResult = oUserPrincipal.GetAuthorizationGroups();
                foreach (Principal oResult in oPrincipalSearchResult)
                {
                    if (oResult.Name.ToLower().Trim() == groupName.ToLower().Trim())
                    {
                        isMember = true;
                    }
                }
            }
            catch { }
            return isMember;
        }
        private static PrincipalContext GetPrincipalContext()
        {
            string domain = "your local domain";
            string defaultOU = "DC=domain here,DC=local";
            string serviceUser = @"domain here\read only system account";
            string servicePassword = @"password goes here";
            PrincipalContext oPrincipalContext = new PrincipalContext(ContextType.Domain, domain, defaultOU, ContextOptions.SimpleBind, serviceUser, servicePassword);
            return oPrincipalContext;
        }
