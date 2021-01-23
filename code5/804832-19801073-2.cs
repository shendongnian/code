    static void Main(string[] args)
    {
        var extended = new DynamicExtension<Person>().ExtendWith<IPerson>();
        var pocoPerson = new Person
        {
            Age = 25,
            FaveQuotation = "2B or not 2B, that is the pencil"
        };
        extended.Person = pocoPerson;
        extended.Name = "Billy";
        Console.WriteLine(extended.Name + " is " + extended.Person.Age 
            + " loves to say: '" + extended.Person.FaveQuotation + "'");
        Console.ReadKey();
    }
