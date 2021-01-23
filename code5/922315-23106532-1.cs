    private static void PatchPerson()
    {
        Console.WriteLine("Patch Person");
        Container c = new Container();
        var person = c.People.Where(p => p.FirstName == "Eric" && p.LastName == "Smith").Single();
        person.Age = 9;
        c.UpdateObject(person);
        c.SaveChanges(SaveChangesOptions.PatchOnUpdate);
        Console.WriteLine("\t{0}, {1}'s age is changed to {2}", person.FirstName, person.LastName, person.Age);
        GetPeople();
    }
