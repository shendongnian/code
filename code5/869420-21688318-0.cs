    public ActionResult ListNames(string _term)
    {
        using (BlueBerry_MTGEntities db = new BlueBerry_MTGEntities())
        {
            db.Database.Connection.Open();
    
            var results = (from c in db.CARD
                       where c.CARD_NAME.ToLower().StartsWith(_term.ToLower())
                       select new {c.CARD_NAME}).Distinct().ToList();
    
            JsonResult result = Json(results.ToList(), JsonRequestBehavior.AllowGet);
    
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
