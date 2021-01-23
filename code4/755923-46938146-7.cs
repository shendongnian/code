    using (var db = new dbContext())
    {
      var person = db.Persons.FirstOrDefaultAsync(p => p.id == 1);
      var pet = db.Pets.FirstOrDefaultAsync(p => p.id == person.PetId);
    }
    Console.WriteLine(person.Pet.Name);  // No Exception Thrown
