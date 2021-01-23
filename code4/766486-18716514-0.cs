    public ActionResult IntermFilter(string id, string code)
    {
        int idFirstAn = (from m in dre.v_AnalysisCountry
                          where m.Code == code && m.Market == id
                          select m.IdAnalysis).FirstOrDefault();
        return RedirectToAction("FilterAnMark", new { id = idFirstAn });
    }
    public ActionResult FilterAnMark(int id)
    {
        var query = (from m in dre.v_AnalysisCountry
                     where m.IdAnalysis == id
                     select m).FirstOrDefault();
        var countries = new FilterManager().ObtainMarkets(query.Code, query.Market);
        ViewBag.code = query.Code;
        ViewBag.market = query.Market;
        return View(countries);
    }
