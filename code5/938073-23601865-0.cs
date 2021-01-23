    public ActionResult Index()
    {            
        return View(new IndexModel());                                 
    }
    [HttpPost]
    public ActionResult ProcessTech(string SubmitButton)
    {	
    	IndexModel _oTechModel = new IndexModel();          
    
    	switch (SubmitButton)
    	{		
    		case "search": //search technician
    			{				
    				_oTechModel.setEnable = true;
    			}
    			break;	
    	}    
    	return View("Index", _oTechModel);         
    }
 
