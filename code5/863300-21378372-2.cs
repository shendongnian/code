    var index = 3;
    var range = 2;
    var qery = employeeList
        .Where(c=>c.ID <= index)
        .OrderByDescending(c=>c.ID)
        .Take(range + 1)
        .Union(
                 employeeList
                   .Where(c=>c.ID >= index)
                   .OrderBy(c=>c.ID)
                   .Take(range + 1)
             );
