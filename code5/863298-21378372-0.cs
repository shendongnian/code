    var index = 3;
    var range = 2;
    var qery = employeeList
        .Where(c=>c.ID <= index)
        .OrderBy(c=>c.ID)
        .Take(range)
        .Union(
                 employeeList
                   .Where(c=>c.ID >= index)
                   .OrderBy(c=>c.ID)
                   .Take(range)
             );
