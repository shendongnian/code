    Person[] r = list.GroupBy(p => new { p.Name, p.AssignedArea })
                     .Select(g => g.ToArray())
                     .Select(g => g.Length > 1
                                  UpdateProgram(g.First()) :
                                  g.First())
                     .ToArray();
    private static Person UpdateProgram(Person p)
    {
        p.Program = "All Programs";
        return p;       
    }
