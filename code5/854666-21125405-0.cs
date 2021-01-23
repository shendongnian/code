        private static string SearchUsers(UserPrincipal parUserPrincipal)
                {
        
                    PrincipalSearcher insPrincipalSearcher = new PrincipalSearcher {QueryFilter = parUserPrincipal};
                    PrincipalSearchResult<Principal> results = insPrincipalSearcher.FindAll();
                    var builder = new StringBuilder();
                    foreach (Principal p in results)
                    {
                        builder.Append(p.SamAccountName);
                        builder.Append("|");
                    }
                    return builder.ToString();
                }
        
        
                public static string SetPrincipal()
                {
                  //Make sure that the name of the domain is correct.
                    var pc = new PrincipalContext(ContextType.Domain, "MYCOMPANY");
                    UserPrincipal insUserPrincipal = new UserPrincipal(pc) {Name = "*"};
                    return SearchUsers(insUserPrincipal);
                }
