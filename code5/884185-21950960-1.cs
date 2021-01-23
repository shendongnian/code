        public ActionResult Index()
        {
            Person p = new Person();
            p.Name = "Rami";
            p.Address = new Address();
            p.Address.State = "California";
            return View(p);
        }
