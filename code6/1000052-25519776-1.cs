    public ActionResult Index()
    {
        ViewBag.countries = new SelectList(db.Countrys, "CountryId", "CountryName");
        return View();
    }
   
     public JsonResult StateList(int Id)
    {
        var state = (from s in db.States
                    where s.CountryId == Id
                    select s).ToList();
         var list = state.Select(m => new { value = m..StateId, text = m.stateName });
        return Json(list, JsonRequestBehavior.AllowGet);
    }
