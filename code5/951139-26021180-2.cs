	public Person GetPerson(string lastName)
    {
        return new Person
        {
            FirstName = "First",
            LastName = lastName, // Return the argument.
            BirthDate = new DateTime(1993, 4, 17, 2, 51, 37, 47, DateTimeKind.Local),
            Id = 0,
            Pets = new List<Pet>
            {
                new Pet { Name= "Generic Pet 1", Color = "Beige", Id = 0, Markings = "Some markings" },
                new Pet { Name= "Generic Pet 2", Color = "Gold", Id = 0, Markings = "Other markings" },
            },
        };
    }
 
