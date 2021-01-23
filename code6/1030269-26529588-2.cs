    private List<string> items;
    public void findAllUser()
    {
        items = new List<string>();
        System.DirectoryServices.DirectoryEntry entry =
            new System.DirectoryServices.DirectoryEntry("LDAP://DC=xyz, DC=com");
        System.DirectoryServices.DirectorySearcher mySearcher =
            new System.DirectoryServices.DirectorySearcher(entry);
        mySearcher.Filter = "(&(objectClass=user))";
        foreach (System.DirectoryServices.SearchResult resEnt in mySearcher.FindAll())
        {
            try
            {
                System.DirectoryServices.DirectoryEntry de = resEnt.GetDirectoryEntry();
                items.Add(de.Properties["GivenName"].Value.ToString() + " " +
                    de.Properties["sn"].Value.ToString() + " " + "[" +
                    de.Properties["sAMAccountName"].Value.ToString() + "]");
            }
            catch (Exception)
            {
                // MessageBox.Show(e.ToString());
            }
        }
    }
