        dynamic anotherPerson = new System.Dynamic.ExpandoObject();
        anotherPerson.FirstName = person.lname;
        Console.WriteLine(anotherPerson.FirstName);
        anotherPerson.PrintPerson = (Action<dynamic>)((p => Console.WriteLine("[{0}] {1}. {2}", p.id, p.lname, p.fname)));
        anotherPerson.PrintPerson(person);
