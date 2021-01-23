    public ActionResult Index(RandomViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(viewModel);
        }
    
        if (Request.HttpMethod == HttpMethod.Post) 
        {
           return RedirectToAction("SomethingNew");
        } 
        else 
        {
           return View(viewModel);
        }
    
    }
