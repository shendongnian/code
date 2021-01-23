    public ActionResult Contractors()
    {
    	var viewModel = new ContractorViewModel();
    	var query = (from c in db.Contractors
                     join cmb in db.ContractorManagedBies on c.ManagedBy equals cmb.ManagedBy
                     join dc in db.DCLocMappings on c.LocationID equals dc.LocationID
                     join at in db.AccountTitles on c.AccountTitleID equals at.AccountTitleID
                     where dc.DeliveryCenter == location
                     select new { cmb.ManagedBy, cmb.ManagerFirstName, cmb.ManagerLastName}).ToList().Select(x => new Contractor {
    				 FullName = x.ManagerFirstName + ' ' + x.ManagerLastName,
    				 ManagedBy = x.ManagedBy
    				 }).ToList();
    				 
    	viewModel.Contractors = query;
    	
    	return View(viewModel);
    }
