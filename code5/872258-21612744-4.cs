    [HttpPost]
    public ActionResult MyMethod
      ([ModelBinder(typeof(MyViewModelBinder))]MyViewModel viewModel)
    {
        // In this point, your list will not come null
        return View();
    }
