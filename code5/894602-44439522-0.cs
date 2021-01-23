        string hostName = "myDomain";
        string adminName = "admin";
        string adminPassword = "password";
                
        public static void ResetPassword(string username, string password)
                {
            using (PrincipalContext pContext = new PrincipalContext(ContextType.Domain, hostName, adminName, adminPassword))
                                    {
                                        UserPrincipal up = UserPrincipal.FindByIdentity(pContext, username);
                                        if (up != null)
                                        {
                                            up.SetPassword(password);
                                            up.Save();
                                        }
                                    }
                            }
