    public static POCO.Thing GetThing(int thingID)
    {
        var proxy = ServiceFactory.CreateNewFooWCFClientInstance();
        try
        {
			var returnValue = proxy.GetThing(thingID);
           	proxy.Close();
           	return returnValue;
        }
        catch(Exception ex)
        {
            //  ***********************************
            //  Error logging boilerplate redacted
            //  ***********************************
            proxy.Abort();
            throw;
        }
    }
