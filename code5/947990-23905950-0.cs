	var time = new []{
		DateTime.Parse("14-4-2012 00:00:00"),
		DateTime.Parse("14-4-2012 01:12:34"),
		DateTime.Parse("14-4-2012 12:44:33"),
		DateTime.Parse("14-4-2012 23:12:42"),
	};
	
	var result = time.Zip(time.Skip(1), (a, b) => b - a)
					 .Select(d => new {d.Hours, d.Minutes, d.Seconds})
					 .ToList();
