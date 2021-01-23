    var persons = new Person[] {
        new Person() { FirstName = "John", LastName = "Appleseed", IsHuman = true },
        new Person() { FirstName = "Compu", LastName = "Tron", IsHuman = false }, 
        new Person() { FirstName = "John", LastName = "Tron", IsHuman = false } 
                               };
    var wheres = new List<Func<Person, bool>>();
    bool filterForJohn = true;
    bool filterForHuman = false;
    if (filterForJohn)
        wheres.Add(new Func<Person, bool>(p => p.FirstName == "John"));
    if (filterForHuman)
        wheres.Add(new Func<Person, bool>(p => p.IsHuman));
    IEnumerable<Person> results = persons;
    foreach (var where in wheres)
        results = results.Where(where);
    foreach (var p in results)
        Console.WriteLine(p.FirstName + ' ' + p.LastName);
