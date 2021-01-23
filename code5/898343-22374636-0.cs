	var data = new List<Data>()
	{
    	new Data() { Id = 1, Name = "Phone", ParentId = 0, Distance = 0 },
    	new Data() { Id = 2, Name = "TV", ParentId = 0, Distance = 0 },
    	new Data() { Id = 3, Name = "battery", ParentId = 1, Distance = 5 },
    	new Data() { Id = 4, Name = "button", ParentId = 1, Distance = 3 },
    	new Data() { Id = 5, Name = "webcam", ParentId = 2, Distance = 5 },
	};
	var lookup = data.ToLookup(x => x.ParentId);
	var devices =
		lookup[0]
			.Select(x => new
			{
				ID = x.Id,
				x.Name,
				Parts =
					lookup[x.Id]
						.Select(y => new
						{
							y.Id,
							y.Name,
							y.Distance,
						})
						.ToList(),
			})
			.ToList();
