    employees
    	.GroupBy(x => x.EmpID)
    	.Select(g => {
    		var byPres = g.OrderByDescending(x => x.DateofPresentation).ToArray();
    		var e = byPres.First();
    		e.Others = byPres.Skip(1).ToList();
    		return e;
    	})
