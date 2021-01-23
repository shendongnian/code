    [AcceptVerbs(HttpVerbs.Get|HttpVerbs.Post)]
    public ActionResult Create(CustomModel viewModel)
    {
        try
        {
            // TODO: Add insert logic here
            // The  button should trigger this method to   perform  update  
            return RedirectToAction("Create");
        }
        catch
        {
            return View();
        }
    }
