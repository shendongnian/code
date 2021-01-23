    using(DirectoryEntry de = new DirectoryEntry("LDAP://servername/DC=phony,DC=com"))
    using(DirectorySearcher ds = new DirectorySearcher(de))
    {
        ds.Filter="(&(objectClass=user)(sAMAccountName="username"))";
        //I don't know exactly what criteria you're using to find the user
        ds.Filter="(&(objectClass=user)(distinguishedname="")(givenname=""))"
        ds.SearchScope = SearchScope.Subtree;
        //performing the search and assigning the result to result
        SearchResult result = ds.FindOne();
        if (result != null)
        {
            using(DirectoryEntry user = result.GetDirectoryEntry())
            {
                //put code here to deal with the user as you see fit.
            }
            lblOutput.Text = "User " + userName + " was found.";
        }
    }
