     private bool ValidateAgainstADAndGroup(string username, string password, string groupname)
                {
                    var ok = false;
                    using (var pc = new PrincipalContext(ContextType.Domain, "mydomain.lan"))
                    {
                        if (pc.ValidateCredentials(username, password))
                        {
                            using (var searcher = new PrincipalSearcher(new UserPrincipal(pc)))
                            {
                                searcher.QueryFilter.SamAccountName = username;
                                Principal u = searcher.FindOne();
                                foreach (Principal p in u.GetGroups())
                                {
                                    if (p.Name == groupname)
                                    {
                                        ok= true;
                                    }
                                }
                            }
                        }
                    }
        
                    return ok;
                }
