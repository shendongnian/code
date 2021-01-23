        var cycleToCheck = 2;
		var query = LstCyclces.FirstOrDefault(c => c.CycleNum == cycleToCheck).Cars
            						.Where(c => LstCyclces.FirstOrDefault(p => p.CycleNum == cycleToCheck - 1).Cars
                								.Any(ca => ca.CarId == c.CarId && Math.Abs(c.Location - ca.Location) < 40));
        
		var result = query.SelectMany(t1 => query.Select(t2 => Tuple.Create(t1, t2)))
				.Where(x => Math.Abs(x.Item1.Location - x.Item2.Location) < 65 && x.Item1.CarId < x.Item2.CarId);
        
		foreach (var r in result)
		{			
			Console.WriteLine("{0} - {1}", r.Item1.CarId, r.Item2.CarId);
		}
