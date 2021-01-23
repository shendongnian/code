    public YourDatabaseNameEntities()
        : base("name=YourDatabaseEntities")
    {
    #if TRACE
    	this.Database.Log = s => System.Diagnostics.Trace.WriteLine(s);
    #endif
    }
