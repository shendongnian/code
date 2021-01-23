    public ActionResult Index()
        {
            var countries = new List<string> {"USA", "UK", "India"};
            var countryOptions = new SelectList(countries);
            ViewBag.Countries = countryOptions;
            return View();
        }
