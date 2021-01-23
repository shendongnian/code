        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Store.Model invoice)
        {
            if (ModelState.IsValid)
            {
                _invoiceRepository.CreateInvoice(invoice);
                // _service is your business service, injected as a dependency via the constructor, same as the _invoiceRepository is now
                invoice.Age = __service.CalcAge(invoice.BirthDate); // or some such thing
                return RedirectToAction("Index");
            }
            return View(invoice);
        }
