    [HttpGet]
    public ActionResult GetAnimals(int id) 
    {
        var viewModel = new AnimalsService(id).GetViewModel();
        return View(viewModel);
    }
