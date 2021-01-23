	using (IDocumentStore store = GetDocumentStore())
	{
		store.Initialize();
		using (var bulkInsert = store.BulkInsert())
		{
			for (var i = 0; i != recordsToCreate; i++)
			{
				var person = new Person
				{
					Id = Guid.NewGuid(),
					Firstname = NameGenerator.GenerateFirstName(),
					Lastname = NameGenerator.GenerateLastName()
				};
				bulkInsert.Store(person);
			}
		}
	}
