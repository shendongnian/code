    [HttpPost]
    public ActionResult DeleteCustomerContact(int id)
    {
      // Call the delete function 
      // e.g. DeleteContact(id);
      // Then re-read your contacts list
      List<CustomerContacts> contacts = GetContacts(...);
    
      return PartialView("_CustomerContactsList", contacts);
    }
