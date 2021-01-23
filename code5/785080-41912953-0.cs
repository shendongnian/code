    using (PrincipalContext oPrincipalContext = new PrincipalContext(ContextType.Domain))
    {
        using (PrincipalContext oGroupContext = new PrincipalContext(ContextType.Machine))
        {
            // find the local group IIS_IUSRS
            using(var gp = GroupPrincipal.FindByIdentity(oGroupContext,"IIS_IUSRS"))
            {
                using (UserPrincipal up = new UserPrincipal(oPrincipalContext))
                {
                    up.SamAccountName = sUserName;
                    up.SetPassword(sPassword);
                    up.Enabled = true;
                    up.PasswordNeverExpires = true;
                    up.Description = "My app's user account";
        
                    up.Save();
                    
                    // add new user to Members of group
                    gp.Members.Add(up);
                    // save before Disposing!
                    gp.Save();
                }
             }
        }
    }
