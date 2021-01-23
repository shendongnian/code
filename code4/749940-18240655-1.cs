    public ActionResult Index()
    {
        List<License> viewModel = new List<License>();
        viewModel.Add(new License() { Id = 1, Name = "Whatever" });
        viewModel.Add(new License() { Id = 2, Name = "Whatever else" });
        viewModel.Add(new License() { Id = 3, Name = "Nevermind this one" });
        return View(viewModel);
    }
