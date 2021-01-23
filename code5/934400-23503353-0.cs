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
    			var x = ex.ToString();
    		}
    	}).Start();
    	return Content("ok");
    }
