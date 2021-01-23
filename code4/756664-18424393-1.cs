    public ActionResult Index()
    {
        var viewModel = new PersonViewModel()
        {
            ListboxData = data.Select(s => new SelectListItem { Value = s.PersonId.ToString(), Text = s.PersonId.ToString() }).AsEnumerable();
        };
        
        return View(viewModel);
    }
    
    [HttpPost]
    public ActionResult Index(PersonViewModel viewModel)
    {
      // code to save the data in the database or whatever you want to do with the data coming from the View
    }
