    public ActionResult Contact(Customer cust)
    {
        try
        {
            if (ModelState.IsValid)
            {
                cust.Tele_comp();
                saveIntoDb(cust); // database
                SendMail(cust); // mail sender
                return RedirectToAction("Submited", "Home");
            }
            return null;
        }
        catch (DataException)
        {
            return View(cust);
        }
    }
    
    private void saveIntoDb(Customer cust)
    {
        using (var cust_In = new DbContext())
        { 
            var customer = new Customer {fname = cust.fname,lname = cust.lname, tele = cust.tele, email = cust.email, reasn = cust.reasn };
            cust_In.Customers.Add(customer); //HERE IS THE ERROR!!!
            cust_In.SaveChanges();
        }    
    }
