    //static headers version
	var qry = Visits.GroupBy(v=>new{v.VisitDate, v.PersonelId})
		.Select(g=>new{
				VisitDate = g.Key.VisitDate,
				PersonelId = g.Key.PersonelId,
				A = g.Where(d=>d.VisitTypeId=="A").Count(),
				B = g.Where(d=>d.VisitTypeId=="B").Count(),
				D = g.Where(d=>d.VisitTypeId=="D").Count(),
				S = g.Where(d=>d.VisitTypeId=="S").Count()
				});
    //dynamic headers version
	var qry = Visits.GroupBy(v=>new{v.VisitDate, v.PersonelId})
		.Select(g=>new{
				VisitDate = g.Key.VisitDate,
				PersonelId = g.Key.PersonelId,
				subject = g.GroupBy(f => f.VisitTypeId)
                          .Select(m => new { Sub = m.Key, Score = m.Count()})
				});
