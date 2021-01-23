        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Store.Model invoice)
        {
            if (ModelState.IsValid)
            {
                invoiceRepository.CreateInvoice(invoice);
                // _service is your business service
                invoice.Age = __service.CalcAge(invoice.BirthDate); // or some such thing
                return RedirectToAction("Index");
            }
            return View(invoice);
        }
