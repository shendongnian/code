    public ActionResult Analyst(int id)
    {
        var ovm = new ObjectiveVM { DatePeriod = new DateTime(2013, 8, 1) };
        var objectives = db.Objectives.Include(
                     o => o.Analyst).Where(x => x.AnalystId == id).ToList();
        ovm.obList = Mapper.Map<IList<Objective>, 
                     IList<ObjectiveVM.ObList>>(objectives);
        return View(ovm);
    }
