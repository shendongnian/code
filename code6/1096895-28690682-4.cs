    using (DirectoryEntry directoryEntry = new DirectoryEntry("LDAP://192.168.1.1/CN=Users,DC=ad,DC=local", 
            name, password))
    {
        using (DirectoryEntry newUser = directoryEntry.Children.Add("CN=CharlesBarker", "user"))
        {
            newUser.Properties["sAMAccountName"].Value = "CharlesBarker";
            newUser.Properties["givenName"].Value = "Charles";
            newUser.Properties["sn"].Value = "Barker";
            newUser.Properties["displayName"].Value = "CharlesBarker";
            newUser.Properties["userPrincipalName"].Value = "CharlesBarker";
            newUser.CommitChanges();
        }
    }
