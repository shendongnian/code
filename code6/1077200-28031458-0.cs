    List<UserPrincipal> results = new List<UserPrincipal>();
    using (var context = new PrincipalContext(ContextType.Domain, ADServerName, ADusername, ADpassword))
                using (var searcher = new PrincipalSearcher(new UserPrincipal(context)))
                {
                    var searchResults = searcher.FindAll();
                    foreach (Principal p in searchResults)
                    {
                      {
    					UserPrincipal userPrincipal = p as UserPrincipal;
    					if (userPrincipal != null)
    						results.Add(userPrincipal);
