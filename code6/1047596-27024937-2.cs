    public void PerformSomeActionAsAdmin(NetworkCredential adminCredential)
    {
        using(LdapConnection connection = new LdapConnection("fabrikam.com", adminCredential))
        {
           // MAGIC
        }
    }
