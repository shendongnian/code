    var res = from d in dept
              join e in emp on d.Id equals e.Departement into cs
              from e in cs.DefaultIfEmpty()
              group e by d into g
              select new
              {
                  Department = g.Key,
                  Employees = g.Where(x => x != null).ToList()
              };
    foreach (var p in res)
    {
        Console.WriteLine("{0} {1} {2}", p.Department.Id, p.Department.Name, p.Employees.Count);
        foreach (var e in p.Employees)
        {
            Console.WriteLine("{0} {1}", e.Id, e.Name);
        }
    }
