    public static void CreateOU()
    {
       DirectoryEntry domain = new DirectoryEntry("LDAP://testdomain.test.com/DC=test,DC=com", "username", "password");
       DirectoryEntry newOU = domain.Children.Add("AnotherOU", "OrganizationalUnit");
       newOU.CommitChanges();
    }
