	var qry = Visits.GroupBy(v=>new{v.VisitDate, v.PersonelId})
		.Select(g=>new{
				VisitDate = g.Key.VisitDate,
				PersonelId = g.Key.PersonelId,
				A = g.Where(d=>d.VisitType=="A").Count(),
				B = g.Where(d=>d.VisitType=="B").Count(),
				D = g.Where(d=>d.VisitType=="D").Count(),
				S = g.Where(d=>d.VisitType=="S").Count()
				});
