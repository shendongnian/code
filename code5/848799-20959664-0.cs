    public void AddToGroup(string userDn, string groupDn)
    {
        try
        {
            DirectoryEntry dirEntry = new DirectoryEntry("LDAP://" + groupDn);
            dirEntry.Invoke("Add", new object[] { userDn });
            dirEntry.CommitChanges();
            dirEntry.Close();
        }
        catch (System.DirectoryServices.DirectoryServicesCOMException E)
        {
            //doSomething with E.Message.ToString();
    
        }
    }
