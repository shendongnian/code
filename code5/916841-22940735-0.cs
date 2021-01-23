    [HttpPost]
    public ActionResult ControllerName(ModelClassName viewModel)
    {
       if (!ModelState.IsValid)
       return View("ViewName", viewModel);//passes validation errors back to the view
       //do w.e
    }
