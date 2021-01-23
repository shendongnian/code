	public int AddDog(Dog dog, List<int> puppyIds)
	{
		dbContext.Dogs.Add(dog);
		dbContext.SaveChanges();
		dbContext.Entry(dog).Reload();
		
		foreach (var puppyId in puppyIds)
		{
			var puppy = dbContext.Puppies.Find(puppyId);
			puppy.DogId = dog.Id;
		}
		
		dbContext.SaveChanges();		
		return dog.Id;
	}
