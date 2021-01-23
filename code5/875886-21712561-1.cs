    public List<Person> GetPersonsList()
        {
            return (from c in context.Persons
                select c).ToList();
        }
    
        //
        // GET: /Address/
    
        public ActionResult Index()
        {
            var model = new PersonModel{ Persons = GetPersonsList()};
            return View(model);
        }
