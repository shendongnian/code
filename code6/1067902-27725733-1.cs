            for(int i = 0; i < domains.Length; i++)
            {
                using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, domains[i], “Login1”, “pass1”))
                {
                    using (UserPrincipal searchPrincipal = new UserPrincipal(pc))
                    {
                         searchPrincipal.Name = "*";
                         using (PrincipalSearcher searcher = new PrincipalSearcher(searchPrincipal))
                         {
                                using (PrincipalSearchResult<Principal> principals = searcher.FindAll())
                                {
                                     foreach (UserPrincipal principal in principals)
                                      {
                                          Console.WriteLine(principal.Name);
                                      }
                                }
                         }
                    }
                }
            }
