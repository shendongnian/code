    class D // do not implement IDisposable, since we don't own connection
    {
        private readonly SqlConnection _conn;
    
        public D(SqlConnection conn)
        {
            // connection is created elsewhere, and will be used by another objects
            _conn = conn;
        }
    
        public void Method2()
        {
            //  read data from database using connnection...
        }
    }
