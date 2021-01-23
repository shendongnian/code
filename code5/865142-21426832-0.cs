    [HttpPost]
    public ActionResult SaveStatement(User currentUser, FormCollection statement, string ViewModelName)
    {
        ...
        object ViewModel = Activator.CreateInstance(type);
        if (TryUpdateModel(viewModel))
        {
            // save the ViewModel
        }   
        return View(ViewModelName, ViewModel);
    }
