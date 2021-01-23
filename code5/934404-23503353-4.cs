    //MVC - works just fine
    public ActionResult ThreadTest()
    {
    	new Thread(delegate() {
    		try
    		{
    			System.Threading.Thread.Sleep(10000);
    		}
    		catch(Exception ex)
    		{
    			//no exception will be thrown
    		}
    	}).Start();
    	return Content("ok");
    }
