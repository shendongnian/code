    static void Main(string[] args)
    {
        var alice = new Person { Name = "Alice" };
        var bob = new Person { Name = "Bob" };
        var colin = new Person { Name = "Colin" };
        var davina = new Person { Name = "Davina" };
        alice.AddWorkRelationship(bob);
        alice.AddWorkRelationship(colin);
        bob.AddWorkRelationship(davina);
        using (var db = new MyContext())
        {
            db.People.AddRange(new[] { alice, bob, colin, davina });
            db.SaveChanges();
        }
        using (var db = new MyContext())
        {
            Console.WriteLine("Bob works with:");
            foreach (Person colleague in db.GetColleagues(bob.Id))
            {
                Console.WriteLine(colleague.Name);
            }
        }
        Console.ReadLine();
    }
