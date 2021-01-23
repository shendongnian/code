    DateTime[] datesOfBirth = new DateTime[] { new DateTime(1955, 10, 28), new DateTime(1955, 2, 24) };
	String[] firstNames = new String[] { "William", "Steve" };
	String[] lastNames = new String[] { "Gates", "Jobs" };
	
	var people = 
		datesOfBirth
		.Select((_, i) => new 
			{ 
				DateOfBirth = datesOfBirth[i],
				FirstName = firstNames[i],
				LastName = lastNames[i]
			})
		.OrderBy(x => x.DateOfBirth)
        .ToArray();
