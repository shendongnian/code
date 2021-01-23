	partial void Trainers_PreprocessQuery(ref IQueryable<Person> query)
	{
		var trainers = new List<Person>();
		Role trainerRole = (from r in Roles where r.Name == "Trainer" select r).Single();
		foreach (PersonRole pr in trainerRole.PersonRoles)
		{
			trainers.Add(pr.Person);
		}
		query = trainers.AsQueryable().Take(trainers.Count());
	}
