        public ViewResult Index()
        {
          using (var db = new CimDataContext())
          {
            IQueryable<Customer> customers = db.Customers;
            return View(customers);
          }
        }
