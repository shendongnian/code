    [AllowAnonymous]
    public ActionResult Register()
    {
		RegisterViewModel viewModel = new RegisterViewModel();
		viewModel.VdabSelectList = new[]
			{
				new SelectListItem { Value = bool.TrueString, Text = "Ja" },
				new SelectListItem { Value = bool.FalseString, Text = "Nee" }
			}
        return View(viewModel);
    }
    [HttpPost]
    public ActionResult Register(RegisterViewModel _viewModel)
    {
		//Do stuff with form data...
    }
	
