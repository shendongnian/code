    using System.DirectoryServices;
    ....
    using (DirectoryEntry de = new DirectoryEntry("LDAP://CN=NewlyCreatedUser,CN=Users,DC=ad,DC=local"))
    {
        de.Properties["userWorkstations"].Add("WS1,WS2");
        de.CommitChanges();
    }
