        public ActionResult Book(long id)
        {
            return View(new CustomerModel
            {
                CompanyId = id
            });
        }
