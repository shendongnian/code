    var employees = ctx.Employee.Where(e => e.Id == Id
                                            && e.Category == Category
                                            && e.DateOfJoining <= date);
    if (!string.IsNullOrWhiteSpace(DATEOFBIRTH))
    {
        employees = employees.Where(e => e.DateOfBirth <= DATEOFBIRTH);
    }
    var data = employees.ToList();
