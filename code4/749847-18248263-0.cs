        //
        // GET: /Objective/Analyst
        public ActionResult Analyst(int id)
        {
            var ovm = new ObjectiveVM().obList;
            var objectives = db.Objectives.Include(o => o.Analyst).Where(x => x.AnalystId == id).ToList();
            ovm = Mapper.Map<IList<Objective>, IList<ObjectiveVM.ObList>>(objectives);
            var ovm2 = new ObjectiveVM();
            ovm2.obList = ovm;
            ovm2.DatePeriod = new DateTime(2013, 8,1);
            return View(ovm2);
        }
