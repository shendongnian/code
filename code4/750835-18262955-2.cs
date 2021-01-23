    public ActionResult Index()
    {
        AppRespository repo = new AppRespository();
        StateModel viewModel = new StateModel();
        viewModel.States = repo.LoadStates();
        return View(viewModel);
    }
