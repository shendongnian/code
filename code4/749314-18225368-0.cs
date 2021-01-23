    [HttpPost]        
    public ActionResult Create(Customer model)
    {
        if (ModelState.IsValid)
        {            
            db.Customers.Add(model);
            try
            {
                db.SaveChanges();
                // here it is ...
                WebSecurity.CreateUserAndAccount(model.Phone, model.Password);
            }
            catch 
            {
                insertError = true;
            }
            // .. Other codes ...
    } 
