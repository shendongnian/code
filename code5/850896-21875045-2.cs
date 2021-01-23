        [HttpPost]
        public ActionResult GenerateContacts(CustomerModel customer)
        {
            // Check whether this request is comming with javascript, if so, we know that we are going to add contact details.
            if (Request.IsAjaxRequest())
            {
                ContactModel contact = new ContactModel();
                contact.ContactName = customer.ContactMode.ContactName;
                contact.ContactNo = customer.ContactMode.ContactNo;
    
                if (customer.Contacts == null)
                {
                    customer.Contacts = new List<ContactModel>();
                }
    
                customer.Contacts.Add(contact);
    
                return PartialView("_Contact", customer);
            }            
        }
