            string employeeId ="someEmployeeId";
            Domain domain = Domain.GetCurrentDomain();
            var searchRoot = domain.GetDirectoryEntry();
            DirectorySearcher search = new DirectorySearcher(searchRoot);
            search.PropertiesToLoad.Add("EmployeeID");
            search.PropertiesToLoad.Add("sAMAccountName");
            search.Filter = String.Format("(&(objectCategory=person)(EmployeeID={0}))", employeeId );
            SearchResult searchResult =search.FindOne();
            if (searchResult != null)
            {
                object o = searchResult.Properties["sAMAccountName"].OfType<object>().FirstOrDefault();
                if (o != null)
                {
                    string sAMAccountName= o.ToString();
                }
            }
