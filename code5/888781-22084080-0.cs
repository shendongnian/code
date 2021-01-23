    public static Contact Login(string username, string passwordHash = null)
    {
        Contact c = GetContactFromDatabase(username) ?? GetContactFromWebService(username, passwordHash);
    
        if (c != null) {
           var context = new CurrentContext();
           context.Contact = c;
           context.Save();
        }
    
        return c;
    }
