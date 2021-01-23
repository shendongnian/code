    var groupedByAge = people.GroupBy(x => x.Age);
    foreach(var item in groupedByAge)
    {
        Console.WriteLine("Age:{0}", item.Key);
        foreach(var person in item)
        {
            Console.WriteLine("{0}",person.Name);
        }
     }
