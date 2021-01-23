    public static void Main()
    {
        Person[] people = new[] 
            { 
                new Person() { Name = "p1", Age = 17 },
                new Person() { Name = "p2", Age = 18 } 
            };
        var onlyOver18 = BuildFilter(new PersonFilter() { Name = null, Age = 18 });
        Console.WriteLine(onlyOver18.ToString());
        foreach (var p in people.Where(onlyOver18.Compile()))
        {
            Console.WriteLine(p.Name);
        }
        Console.ReadKey();
    }
