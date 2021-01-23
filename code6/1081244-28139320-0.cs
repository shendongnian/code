    var employees = context.Employees
        .Select(e => new
        {
            Employee = e,
            EmployeeProfiles = e.EmployeeProfiles,
            Nationalities = e.EmployeeProfiles.Select(a => a.Nationality)
        })
        .ToList() // do this to force the projection
        .Select(e => new EmployeeLeatestProfileModel
        {
            EmployeeId = e.Employee.EmployeeId,
            EmpNum = e.Employee.EmpNum,
            LastUpdatedProfile = e.EmployeeProfiles
                .Where(p => p.EmployeeId == e.Employee.EmployeeId)
                .OrderByDescending(a => a.UpdateDatetime)
                .Take(1)
        })
        .ToList();
