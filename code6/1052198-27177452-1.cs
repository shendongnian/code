	ModelState.Remove("Captcha");
	ModelState.Remove("Password");
	ModelState.Remove("RetypePassword");
	if (ModelState.IsValid)
    {
		var existingCustomer = db.Customers.First(c => c.ID == customer.ID);
		
		// Update properties of attached entity
		existingCustomer.FirstName = customer.FirstName;
		existingCustomer.LastName = customer.LastName;
        // and so on...
