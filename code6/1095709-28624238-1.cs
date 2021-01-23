    public ActionResult MyForm()
    {
        var vm = new ViewModel
        {
            Locations = context.Locations.ToList() // Some database call
        }
    
        return View(vm);
    }
    
    [HttpPost]
    public ActionResult MyForm(ViewModel vm)
    {
        vm.Locations // this is null
    }
