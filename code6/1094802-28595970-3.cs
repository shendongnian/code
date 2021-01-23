    // Load Page
    [HttpGet]
    public ActionResult MyPage()
    {
        var viewModel = new PageViewModel();
        viewModel.MyForm = new MyFormViewModel();
        return View(viewModel);
    }
    
    // SubmitForm: Accepts MyFormViewModel
    [HttpPost]
    public ActionResult MyPage(MyFormViewModel viewModel)
    {
       // do something with form data
    }
