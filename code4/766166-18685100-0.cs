    Person person... // your new person with a collection of pets
    using (var ctx = new MyContext())
    {
        var pets = person.Pets;
        var petNames = pets.Select(p => p.Name);
        person.Pets.Clear();
        var existingPetsDict = ctx.Pets
            .Where(p => petNames.Contains(p.Name))
            .ToDictionary(p => p.Name);
        foreach (var pet in pets)
        {
            Pets existingPet;
            if (existingPetsDict.TryGetValue(pet.Name, out existingPet))
                person.Pets.Add(existingPet);
            else
                person.Pets.Add(pet);
        }
        ctx.Persons.Add(person);
        ctx.SaveChanges();
    }
