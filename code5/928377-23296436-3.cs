    [HttpPost]
    public ActionResult Create(CreateCustomerVM customer)
    {
      if(ModelState.IsValid)
      {
        //read customer.FirstName , customer.MidName 
        // Map it to the properties of your DB entity object
        // and save it to DB
      }
      //Let's reload the MidNames collection again.
      customer.MidNames=GetMidNames();
      return View(customer);
    }
