    bool emptyDep = true;
    foreach (Department d in u.Departments)
    {
          if (!d.Any())
          {
              emptyDep = true;
              Console.WriteLine(d.ToString());
          }
    }
    if (!emptyDep)
    {
        Console.WriteLine("All departments contain students")
    }
