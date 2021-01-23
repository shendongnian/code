    public Test1Controller
    {
          public ActionResult SomeMethod()
          {
    			//do mvc stuff
    			
    			//do WebSecurity stuff	
    			
    			//do your stuff
    			MyLogicHere();
          }
    
    	//public only so it can be tested
    	public MyLogicHere()
    	{
    		//the logic in here does not have dependencies on difficult to test types 
    	}
    }
