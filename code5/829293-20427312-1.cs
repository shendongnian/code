    [HttpPost]
    public PartialViewResult UpdateDetails(Customer customer)
    {
        var existingCustomer = GetCustomer(id);
        if(existingCustomer!=null)
        {
          existingCustomer.Name=customer.Name;
          UpdateCustomer(existingCustomer);
          return PartialView("CustomerUpdateResult", true);
        }
        return PartialView("CustomerNotFound", true);
    }
