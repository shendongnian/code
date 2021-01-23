    using (var context = new ERPDataContext())
    {
    	var STD = context.STUDENTs.SingleOrDefault(obj=>obj.ID==idToLookup);
    	
    	if (STD != null)
    	{
    	     STD.SomeValue = someValue;
    	}
    	
    	context.SubmitChanges(); // submit *CHANGES*
    }
