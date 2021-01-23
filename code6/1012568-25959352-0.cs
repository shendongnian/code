    public static class ClientContextFactory
    {
        public static MyDbContext(string userName)
        {
            //look up the user to find his database
            //build connectio string based on users database
            return new MyDbContext(userConnectionString);
        }
    }
