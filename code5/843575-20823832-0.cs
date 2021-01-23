    using (DirectoryEntry deRoot = new DirectoryEntry("LDAP://RootDSE"))
    {
        if (deRoot.Properties["defaultNamingContext"] != null)
        {
            string defaultNamingContext = 
                   deRoot.Properties["defaultNamingContext"].Value.ToString();
        }
    }
