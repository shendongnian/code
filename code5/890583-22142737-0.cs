    foreach (var person in list)
    {
        Console.WriteLine(person.Firstname + " " + person.Lastname + ":");
        foreach(var pet in person.Pets) // iterate over Pets of person
        {
            Console.WriteLine("   " + pet.Firstname); // write pet's name
        }
    }
