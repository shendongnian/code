         private bool ValidateAgainstADAndGroup(string username, string password, string groupname)
                    {
                        var ok = false;
                        using (var pc = new PrincipalContext(ContextType.Domain, "mydomain.lan"))
                        {
                            if (pc.ValidateCredentials(username, password))
                            {
                                //User is alright
                                using (var searcher = new PrincipalSearcher(new UserPrincipal(pc)))
                                {
                                    searcher.QueryFilter.SamAccountName = username;
                                    Principal u = searcher.FindOne();
                                    foreach (Principal p in u.GetGroups())
                                    {
                                        if (p.Name == groupname)
                                        {
                                            //User is in group
                                            ok= true;
                                        }
                                    }
                                }
                            }
                        }
            
                        return ok;
                    }
