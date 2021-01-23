	private static void SetAccessCode(string guidCode)
	{
	    using (EPOSEntities db = new EPOSEntities())
	    {
	        ClientAccountAccess client = new ClientAccountAccess();
	        client.GUID = guidCode;
            // ClientAccountAccess is name of your DBSet in context. It might be different
	        db.ClientAccountAccess.AddObject(client); 
	        db.SaveChanges();
	    }
	}
