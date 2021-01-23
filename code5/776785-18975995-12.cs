    //24-SEP-2013::FNG - put backing field for ConnectionString as we're now doing constructor injection of it
    public string ConnectionString
    {
       {get { return _connectionString; } }
       {set {_connectionString="foo"; } }//FNG: I'll change this later on, I'm in a hurry
    }
    
    ///snip
    
    public MyDBClass(string connectionString)
    {
       ConnectionString=connectionString;
    }
