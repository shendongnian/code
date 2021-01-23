    private static void SetAccessCode(string guidCode)
    {
    	using (EPOSEntities db = new EPOSEntities())
    	{
    		var c= db.ClientAccountAccesses.FirstOrDefault(f=>f.GUID==guidCode);
    		if(c==null)
    		{
    			c=new ClientAccountAccess();
    			db.AddToClientAccountAccesses(client);
    		}
    		c.GUID=guidCode;
    		db.SaveChanges();
    	}
    }
