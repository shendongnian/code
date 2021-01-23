    public ActionResult Contact()
    {
         var contact = new Contact
         {
            Address = new Address
                      { 
                           Line1 = "111 First Ave N.",
                           Line2 = "APT 222",
                           City = "Miami",
                           State = "FL",
                           Zip = "33133"
                      }
         }
         return View(contact);
    }
