    public ActionResult MyAction()
    {
        string theThingToParse = "1000000";
        ViewModel viewModel = new ViewModel();
        if(!string.IsNullOrEmpty(theThingToParse))
        {
            viewModel.Price = int.parse(theThingToParse);    
        }
        
        return View(viewModel);
    }
 
