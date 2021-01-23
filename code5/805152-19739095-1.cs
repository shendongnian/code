    [HttpPost]
    public ActionResult Create(ViewModel viewModel)
    {
        string birthday = viewModel.Month + "/" + viewModel.day + "/" + viewModel.year;
        
        Model model = new Model { Birthday = Convert.ToDateTime(birthday) } ;
        // save 
        return RedirectToAction("Index");
    }
