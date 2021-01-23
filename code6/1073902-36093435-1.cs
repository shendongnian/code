    public ActionResult Create()
            {
    
                ViewBag.CustomerId = new SelectList(db.Customers, "Id", "FullName");
                ViewBag.CountryId= new SelectList(db.Countries, "CountryId", "CountryName");
                return View();
            }
            public JsonResult StateList(int Id)
            {
                var state = from s in db.States
                            where s.CountryId == Id
                            select s;
    
                return Json(new SelectList(state.ToArray(), "StateId", "StateName"), JsonRequestBehavior.AllowGet);
            }
    
            public JsonResult Citylist(int id)
            {
                var city = from c in db.Cities
                           where c.StateId == id
                           select c;
    
                return Json(new SelectList(city.ToArray(), "CityId", "CityName"), JsonRequestBehavior.AllowGet);
            }
    
            public IList<State> Getstate(int CountryId)
            {
                return db.States.Where(m => m.CountryId == CountryId).ToList();
            }
            [AcceptVerbs(HttpVerbs.Get)]
            public JsonResult LoadClassesByCountryId(string CountryName)
            {
                var stateList = this.Getstate(Convert.ToInt32(CountryName));
                var stateData = stateList.Select(m => new SelectListItem()
                {
                    Text = m.StateName,
                    Value = m.CountryId.ToString(),
                });
                return Json(stateData, JsonRequestBehavior.AllowGet);
            }
