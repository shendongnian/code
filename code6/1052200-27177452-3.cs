	public ActionResult Edit(EditCustomerModel customer)
	{
		if (ModelState.IsValid)
		{
			var existingCustomer = db.Customers.First(c => c.ID == customer.ID);
			
			// Update properties of attached entity
			existingCustomer.FirstName = customer.FirstName;
			existingCustomer.LastName = customer.LastName;
			
			db.SaveChanges();
			
			return RedirectToAction(...);
		}
		
		return View();
	}
