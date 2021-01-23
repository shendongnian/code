    [HttpPost]
    public ActionResult Create(CustomModel viewModel )
    {
        try
        {
            // TODO: Add insert logic here
            // The  button should trigger this method to   perform  update
            // Return "Create" view, with the posted model
            return View(model);
        }
        catch
        {
            // Do something useful to handle exceptions here.
            // Maybe add meaningful message to ViewData to inform user insert has failed?
            return View(model);
        }
    }
