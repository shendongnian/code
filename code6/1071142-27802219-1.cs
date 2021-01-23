    public static List<string> GetUserGroupDetails(string userName)
            {
    
                DirectorySearcher search = new DirectorySearcher();
                List<string> groupsList = new List<string>();
                search.Filter = String.Format("(cn={0})", userName);
                search.PropertiesToLoad.Add("memberOf");
    
                SearchResult result = search.FindOne();
                if (result != null)
                {
                    int groupCount = result.Properties["memberOf"].Count;
    
                    for (int counter = 0; counter < groupCount; counter++)
                    {
                        string s = (string)result.Properties["memberOf"][counter];
                        groupsList.Add(s);
                        // _log.DebugFormat("found group for user {0} : {1}", userName, s);
    
                    }
                }
                else
                {
                    _log.Warn("no groups found for user " + userName);
                }
                return groupsList;
            }
