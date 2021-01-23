    public ActionResult Register(...)
    {
        List<Customer> customers;
    
        using (GatewayContext db = new GatewayContext())
        {
            customers = db.Customers.ToList();
        }
    
        var viewModel = new RegisterViewModel();
        viewModel.Customers = customers;
        return View(viewModel);
    }
