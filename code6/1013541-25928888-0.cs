    DirectorySearcher searcher;
    SearchResultCollection results;
    searcher = new DirectorySearcher();
    searcher.Filter = "(&(objectClass=user)(objectCategory=person))";
    searcher.PropertiesToLoad.Add("DirectReports");
    searcher.PropertiesToLoad.Add("mail");
    searcher.SearchRoot = utilityDomain;
    Dictionary<string, string> managerEmailAddresses = new Dictionary<string, string>();
    using (searcher)
    {
        results = searcher.FindAll();
        foreach (SearchResult result in results)
        {
            if (result.Properties["DirectReports"].Count > 0)
            {
                DirectoryEntry emp = result.GetDirectoryEntry();
                String mail = "";
                if (emp.Properties["mail"].Count > 0)
                {
                    mail = emp.Properties["mail"][0].ToString();
                    string userName;
                    userName= mail.Split('@')[0];
                    managerEmailAddresses.Add(userName, mail);
                 }
             }
        }
        return managerEmailAddresses;
    }
