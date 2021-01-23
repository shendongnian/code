    PrincipalContext ctx = new PrincipalContext(ContextType.Domain, domainName + ":389");
            string FirstName = "Jane";
            string LastName = "Smith";
            for (int i = 1; i <= FirstName.Length; i++)
            {
                string username = LastName + FirstName.Remove(i);
                UserPrincipal user = UserPrincipal.FindByIdentity(ctx, IdentityType.SamAccountName, username);
                if ((object)user == null) //user doesn't exists
                {
                    #region Add User
                    try
                    {
                        UserPrincipal userex = new UserPrincipal(ctx, username, password, true);
                        userex.GivenName = firstname;
                        userex.Surname = lastname;
                        userex.DisplayName = firstname + " " + lastname;
                        userex.ExpirePasswordNow();
                        userex.Description = _UserDescr;
                        userex.Save();
                        break;
                    }
                    catch
                    {
                        //
                    }
                    #endregion
                }
            }
