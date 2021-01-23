    var list = results.AsEnumerable()....
    TempData["results"] = list;
    return RedirectToAction("MatchedBusinesses", "Home");
    public ActionResult MatchedBusinesses()
    {
      List<Business> businesses = (List<Business>)TempData["results"];
    }
