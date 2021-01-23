    public ActionResult TestAction(string id)
    {
    	if(CanAccessThisAction("TestAction",PermType.Perm1|PermType.perm3|PermType.perm5))
    	{
    		//do your work here
    	}
    	else
    	{
    		//redirect user to some other page which says user is not authorized
    	}
    }
