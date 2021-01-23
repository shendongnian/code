        private void TestTheMethods()
        {
            //Search for the user, in the ou "user" 
            DirectoryEntry user = GetUser("FirstName LastName","FullOrganisationUnitPath");
            //Found user?
            if (user == null) { return; }
                
            //ValidateUser
            if (!ValidateUser(user, "userPassword")) { return; }
        }     
    
        public static DirectoryEntry GetUser(string userName, string rootWeAreLooking = "")
        {
            DirectoryEntry user = null;
    
            using(DirectoryEntry searchRoot = new DirectoryEntry(rootWeAreLooking))
            using(DirectorySearcher searcher = new DirectorySearcher(searchRoot))
            {
                searcher.Filter = String.Format("(&(objectCategory=person)(cn={0}))",userName);
                searcher.SearchScope = SearchScope.Subtree;
    
                SearchResult result = searcher.FindOne();
                if (result == null) { return null; }
                
                //Found user
                return result.GetDirectoryEntry();
            }
        }
    
        public static Boolean ValidateUser(DirectoryEntry entry, string pwd)
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
