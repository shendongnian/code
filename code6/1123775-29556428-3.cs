        private void TestTheMethods()
        {
            //Search for the user, in the ou "user" 
            DirectoryEntry user = GetUser("FirstName LastName","FullOrganisationUnitPath");
            //Found user?
            if (user == null) { return; }
                
            //ValidateUser
            if (!ValidateUser(user, "userPassword")) { return; }
        }     
    
        public DirectoryEntry GetUser(string userName, string rootWeAreLooking = "")
        {
            DirectoryEntry user = null;
    
            using(DirectoryEntry searchRoot = new DirectoryEntry(rootWeAreLooking))
            using(DirectorySearcher searcher = new DirectorySearcher(searchRoot))
            {
                searcher.Filter = String.Format("(&(objectCategory=person)(cn={0}))",userName);
                //searcher.SearchScope = SearchScope.Subtree;
                //SearchScope.Subtree --> Search in all nested OUs
                //SearchScope.OneLevel --> Search in the Ou underneath
                //SearchScope.Base    --> Search in the current OU
                
                search.SearchScope = SearchScope.OneLevel;
    
                SearchResult result = searcher.FindOne();
                if (result == null) { return null; }
                
                //Found user
                return result.GetDirectoryEntry();
            }
        }
    
        public Boolean ValidateUser(DirectoryEntry entry, string pwd)
        {
            Boolean isValid = false;
    
            try
            {
                DirectoryEntry validatedUser = new DirectoryEntry(entry.Path, entry.Name.Remove(0,3), pwd);
                //Check if we can access the Schema
                var Name = validatedEntry.SchemaEntry;
                //User exits, username is correct and password is accepted
                isValid = true;
            }
            catch(DirectoryServicesCOMException ex)
            {
                isValid = false;
                ///User wrong? wrong password?
            }
    
            return isValid;
        }
