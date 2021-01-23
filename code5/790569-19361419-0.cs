    List<string> GetUserDetails()
        {
            List<string> allUsers = new List<string>();
            PrincipalContext ctx = new PrincipalContext(ContextType.Domain, "myDomain",
                                                    "OU=ounit,dc=myDC,dc=com");
            UserPrincipal qbeUser = new UserPrincipal(ctx);
            qbeUser.GivenName = _UITxtUserName.Text;
            PrincipalSearcher srch = new PrincipalSearcher(qbeUser);
            foreach (var found in srch.FindAll())
            {
                allUsers.Add(found.DisplayName + "(" + found.SamAccountName + ")");
            }
            qbeUser = null; 
            qbeUser = new UserPrincipal(ctx);
            qbeUser.Surname = _UITxtUserName.Text;
            PrincipalSearcher srch1 = new PrincipalSearcher(qbeUser);
            foreach (var found in srch1.FindAll())
            {
                allUsers.Add(found.DisplayName + "(" + found.SamAccountName + ")");
            }
            allUsers.Sort();
            return allUsers;
        }
