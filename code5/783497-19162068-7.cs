    public ActionResult List()
    {
    	var customerModel = db.Customers.Select(c => new CustomerModel
    													 {
    														Id = c.Id,
    														Name = c.Name,
    														EmailAddress = c.EmailAddress
    													 }).ToList();
    	return View(customerModel);
    }
