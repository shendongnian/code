    public MyContext : DbContext
    {
        public MyContext() : base("name=MyContext")
        {
            // the terrible hack
            var ensureDLLIsCopied = 
                    System.Data.Entity.SqlServer.SqlProviderServices.Instance;   
        }
