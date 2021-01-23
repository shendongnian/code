    List<Person> persons = new List<Person>();
    persons.Add(new Person() { Firstname = "Sam", Lastname = "Car", BirthDate = new DateTime(2001, 01, 01), PersonId = 1, Sex = Sex.Man });
    persons.Add(new Person() { Firstname = "Kate", Lastname = "Bed", BirthDate = new DateTime(1995, 11, 11), PersonId = 2, Sex = Sex.Woman, Pets = new List<Pet>() { new Pet { Firstname = "Rex", BirthDate = new DateTime(2007, 1, 1), Sex = Sex.Man, PetId = 1 }, new Pet { Firstname = "Sally", BirthDate = new DateTime(2004, 2, 1), Sex = Sex.Woman, PetId = 2 } } });
    persons.Where(p => p.Pets != null && p.Pets.Any()).ToList().ForEach(p =>
    {
        Console.WriteLine(p.Firstname + " " + p.Lastname + "\n");
        p.Pets.ForEach(pt => Console.WriteLine(pt.Firstname));
    });
