     using (var pc = new PrincipalContext(ContextType.Domain, "domain.lan", username, password))
                {
                    if (pc.ValidateCredentials(username, password))
                    {
                        try
                        {
                            using (var searcher = new PrincipalSearcher(new UserPrincipal(pc)))
                            {
                                searcher.QueryFilter.SamAccountName = username;
                                Principal u = searcher.FindOne();
                            }
                        }
                        catch (Exception)
                        {
                            return "no rights to work on ad";
                        }
                    }
                    else
                    {
                        return "user cannot login";
                    }
                }
