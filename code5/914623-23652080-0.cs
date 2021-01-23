    public static string CheckActiveDirectoryAccount(string account)
            {
                UserPrincipal user;
                PrincipalContext context;
                List<string> userPrincipalNameList;
                string ADServer = null;
                string ADUserName = null;
                string ADUserPassword = null;
    
                string userAccount;
    
                account = account.ToLower();
                GetADSettings(out ADServer, out ADUserName, out ADUserPassword);
    
                if (ADUserName.Length > 0)
                    context = new PrincipalContext(ContextType.Domain, ADServer, null,  ADUserName, ADUserPassword);
                else
                    context = new PrincipalContext(ContextType.Domain, ADServer);
    
                using (context)
                {
                    if((user = UserPrincipal.FindByIdentity(context, account)) == null)
                    {
                        if(account.Contains("\\"))
                        {
                            userPrincipalNameList = user.UserPrincipalName.Split('\\').ToList();
    
                            if (userPrincipalNameList.Count > 0)
                                user = UserPrincipal.FindByIdentity(context, userPrincipalNameList[0]);
                        }
                    }
    
                    if (user != null)
                    {
                        using (user)
                        {
                            userPrincipalNameList = user.UserPrincipalName.Split('@').ToList();
    
                            userAccount = userPrincipalNameList.First();
    
                            if (userPrincipalNameList.Count > 1)
                                userAccount = userPrincipalNameList.Last() + "\\" + userAccount;
    
                            if (user != null)
                                return userAccount.ToLower();
                        }
                    }
                }
                return string.Empty;
            }
