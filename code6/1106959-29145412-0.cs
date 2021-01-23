    [HttpPost]
        public ActionResult Index(string btnSubmit, Customer customer)
        {
            int CustomerContactID = Convert.ToInt32(btnSubmit);
 
            if (!ModelState.IsValid)
            {
                return View(customer);
            }
 
            int indexOfCust = customer.CustomerContacts.FindIndex(c => c.ID == CustomerContactID);
            customer.CustomerContacts.RemoveAt(indexOfCust);
            ModelState.Clear();
            return View(customer);
        }
