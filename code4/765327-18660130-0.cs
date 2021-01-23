    public ActionResult Index()
    {
        var products = _db.Products.ToArray() // force loading the results from database 
                                               // and close the datareader
        var viewModel = products.Select(product => GetMedicalProductViewModel(product));
       
        return View(viewModel);
    }
