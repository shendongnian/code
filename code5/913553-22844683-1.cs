	var query =
		ctx.ConferenceRoom
			.Where(cr => cr.IsAccessibleGlobally == 1)
			.Select(cr => new { cr.ID, cr.Name })
			.Concat(
				ctx.Department
					.Where(d => d.Id == 7)
					.Select(d => 
						d.ConferenceRooms
						.Where(cr => cr.IsAccessibleGlobally == 0)
						.Select(cr => new { cr.ID, cr.Name }))
			)
