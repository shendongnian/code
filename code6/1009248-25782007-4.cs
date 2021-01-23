    void Main()
    {
    	try 
    	{
    	 MyObject activator = new ...
         AnotherObject db_connection = new ...
         Proxy p = new ...
         // some other variables 
         if(..)
          return;
    	 if (...)
    	 	return;
    	}
    	finally
    	{
            // Deactivate activator, close db connection, call a webservice to confirm user exited
            // Do some post calculations
    	}
    }
