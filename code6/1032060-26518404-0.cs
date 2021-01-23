	Vehicles
		.Select(x => new
		{
			EngineSize = x.Mechanics.Engine.Size,
			PassengersCount = xs.Passengers.Count,
		})
		.ToArray()
		.GroupBy(v => v.EngineSize)
        .Select(g => g.Sum(s => s.PassengersCount)); 
