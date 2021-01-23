    // pseudo-code
    public ActionResult Indes(int customerId)
    {
        var viewModel = new ViewModel();
        viewModel.Value = dbContext.Customers.FirstOrDefault(c => c.CustomerId == customerId);
        viewModel.DisplayName = dbContext.FieldNames.FirstOrDefault(f => f.Name == some condition);
    
        return View(viewModel);
    }
