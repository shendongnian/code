    Person[] r = list.GroupBy(p => p.Name)
                     .Select(g => Do(g.ToArray())
                     .ToArray();
    private static Person Do(Person[] person)
    {
        var p = persons[0];
        if (persons.Length > 0)
        {
            p.Program = "All Programs";
        }
        return p;       
    }
