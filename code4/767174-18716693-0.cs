    public ActionResult Filter(string id)
    {
        ViewBag.code = id;
        var merc = from a in dre.v_AnalysisCountry
                   where a.Code == id
                   select a;
        var query1 = merc.Select (a => new { a.Code,a.Market}).Distinct().OrderBy(a => a.Market);
        ViewBag.mar = new SelectList(query1.AsEnumerable(), "Market", "Market");
        return View();
    }
    public ActionResult IntermFilter(string id, string code)
    {
        int idFirstAn = (from m in dre.v_AnalysisCountry
                         where m.Code == code && m.Market == id
                         select m.IdAnalysis).FirstOrDefault();
        return RedirectToAction("FilterMarket", new { id = idFirstAn });
    }
    public ActionResult FilterMarket(int id)
    {
        var query = (from m in dre.v_AnalysisCountry
                     where m.IdAnalysis == id
                     select m).FirstOrDefault();
        var countries = new FilterManager().ObtainAnMarket(query.Code, query.Market);
        return View(countries);
    }
