    public void PerformSomeActionAsAdmin(string adminUsername, string adminPassword)
    {
        //Null causes the constructor to connect to the current domain the machine is on.
        //                                                                       |
        //                                                                       V
         using (PrincipalContext ctx = new PrincipalContext(ContextType.Domain, null, adminUsername, adminPassword))
        {
            //do something here with ctx, the operations will be performed as whoever's username and password you passed in.
        }
    }
