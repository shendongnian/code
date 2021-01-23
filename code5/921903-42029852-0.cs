    using (ApplicationDbContext context = new ApplicationDbContext())
    {
        var person = new Person
                         {
                             FirstName = "Random",
                             LastName = "Person";
                         };
    
        context.People.Add(person);
        context.SaveChanges();
        Console.WriteLine(person.Id);
    }
