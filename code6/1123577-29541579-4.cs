    public ActionResult CountryList()
    {
        using (var db = new MyDbContext())
        {
            var countries = db.Countries.ToList();
            return Json(
                new SelectList(countries, "CountryCode", "CountryName"), JsonRequestBehavior.AllowGet);
        }
    }
    
    public ActionResult StateList(string countryCode)
    {
        using (var db = new MyDbContext())
        {
            var states = !string.IsNullOrEmpty(countryCode)
                ? db.States.Where(state => state.CountryCode == countryCode).ToList()
                : new List<State>();
            return Json(
                new SelectList(states, "StateID", "StateName"), JsonRequestBehavior.AllowGet);
        }
    }
