    [HttpPost]
    public ViewResult Edit(Customer customer) {
        if (ModelState.IsValid) {
            // Save your customer
            return RedirectToAction("Index");
        }
        else {
            return View(customer);
        }
    }
