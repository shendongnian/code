    public MyController : Controller {
    
    	public ActionResult GetFile()
    	{
    		// ...
    		
    		return File(stream, "application/octet-stream", "file.xls");
    	}
    
    }
