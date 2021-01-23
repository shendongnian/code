    public ActionResult Index()
    {
        var viewModel = new PersonViewModel
        {
            Names = new List<NameViewModel>
            {
                new NameViewModel {Id = 1, FirstName = "Stephen", MiddleName = "M", LastName = "Abney"},
                new NameViewModel {Id = 2, FirstName = "Jim", LastName = "Beam"}
            }
        };
        return View(viewModel);
    }
    [HttpPost]
    public ActionResult Index(PersonViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            NameViewModel primaryName = viewModel.Names.SingleOrDefault(m => m.Id == viewModel.Primary);
            // save the data
        }
        return View(viewModel);
    }
