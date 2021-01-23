    var toModel = ToModel();
    var departments2 = db.departments
        .AsExpandable()
        .Include(p => p.employee)
        .Where(p => true)
        .Select(p => new CustomDepartmentModel()
    {
        ID = p.ID,
        Employees = toModel.Invoke(p.employee).ToList()
    });
