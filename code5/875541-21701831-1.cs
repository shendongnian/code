    private static void SetAccessCode(string guidCode)
    {
    	using (EPOSEntities db = new EPOSEntities())
    	{
    		var c= db.ClientAccountAccesses.FirstOrDefault(f=>f.GUID==guidCode);
    		if(c!=null)
    		{
    			db.ClientAccountAccesses.DeleteObject(c);
    			db.SaveChanges();
    		}
    		var client = new ClientAccountAccess(){GUID=guidCode};
    		db.AddToClientAccountAccesses(client);
    		db.SaveChanges();
    	}
    }
