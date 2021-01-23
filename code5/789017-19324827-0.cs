    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Customer customer)
    {
        if (ModelState.IsValid)
        {
            _customerRepository.Add(customer);
            return RedirectToAction("Index");
        }
        return View("Create", customer);
    }
