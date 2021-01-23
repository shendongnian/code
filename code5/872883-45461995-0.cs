    public void List<string> PagedSearch()
    { 
        var list = new List<string>();
        bool lastPage = false;
        int start = 0, end = 0, step = 1000;
        var rootEntry = new DirectoryEntry("LDAP://domain.com/dc=domain,dc=com", "user", "pwd");
        var filter = "(&(objectCategory=person)(objectClass=user)(samAccountName=*foo*))";
        using (var memberSearcher = new DirectorySearcher(rootEntry, filter, null, SearchScope.Base))
        {
            while (!lastPage)
            {
                start = end;
                end = start + step - 1;
                memberSearcher.PropertiesToLoad.Clear();
                memberSearcher.PropertiesToLoad.Add(string.Format("member;range={0}-{1}", start, end));
                var memberResult = memberSearcher.FindOne();
                var membersProperty = memberResult.Properties.PropertyNames.Cast<string>().FirstOrDefault(p => p.StartsWith("member;range="));
                if (membersProperty != null)
                {
                    lastPage = membersProperty.EndsWith("-*");
                    list.AddRange(memberResult.Properties[membersProperty].Cast<string>());
                    end = list.Count;
                }
                else
                {
                    lastPage = true;
                }
            }
        }
        return list;
    }
