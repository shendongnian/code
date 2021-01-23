    private static object DatabaseLock = new object();
    
    public CustomObject GetObject(string username, string userTeam)
    {
    	lock (DatabaseLock)
    	{
    	    int tokenID = Database.GetNextToken(username, userTeam);
    
    	    MainDataLayer.LoadData loadData = new MainDataLayer.LoadData();
    	    return loadData.GetObject (tokenID);
        }
    }
