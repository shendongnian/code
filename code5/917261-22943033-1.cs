    public ActionResult Index() 
    {
    	//create the PostView model
    
    	var pv = new PostView();
    	pv.ContactManager = contactManager;
    	pv.post = new PostView()
    	{
    		ContactID = contactManager.Contact.Id,
    		SalutationID = contactManager.SalutationType.Id,
    		FirstName = contactManager.Contact.FirstName
    	};
    
    	return View(pv);
    }
