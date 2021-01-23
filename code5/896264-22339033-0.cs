     try             
     {
    DirectoryEntry ouEntry = new DirectoryEntry("LDAP://localhost:389/ou=people,dc=wso2,dc=com","cn=admin,dc=wso2,dc=com", "toto", AuthenticationTypes.Secure);
    DirectoryEntry childEntry = ouEntry.Children.Add("CN=tati toto", "top");
    childEntry.Properties["objectclass"].Add("person");
    childEntry.Properties["sn"].Add("toto");
    childEntry.CommitChanges();
     }
     catch(Exception Ex)             
    {
    Console.WriteLine("Exception : "+ Ex.Message);
    }
