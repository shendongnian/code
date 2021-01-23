    //GET: /Checkout/AddressAndPayment 
    public ActionResult AddressAndPayment(int userId)
    {
       var user = storeDB.UserProfiles.FirstOrDefault(u => u.Id == Id);
       var billing = new Billing();
       billing.AdresseBilling = user.Adresse;
       //etc... add anything else you need here
       return View(billing);
    }
