    bool errors = false;
    foreach (Department d in u.Departments)
         if (d.students.Count == 0) // students is IList<> it has a property Count
         {
              Console.WriteLine(d.name); // name is string
              errors = true;
         }
    if (!errors)
        Console.WriteLine("All departments contain students");
