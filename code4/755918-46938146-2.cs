    using (var db = new dbContext())
    {
      var person = db.Persons
        .Include(p => p.Pet)
        .FirstOrDefaultAsync(p => p.id == 1);
    }
    Console.WriteLine(person.Pet.Name);  // No Exception Thrown
