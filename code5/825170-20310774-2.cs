    public ActionResult DeleteAll()
    {
        IEnumerable<Customer> customerList = db.Customers.Where(i => i.IsDeleted == true);
        return View(customerList);
    }
