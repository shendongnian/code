    if (JobTitleID.HasValue)
        {
            employees = employees.Where(j => j.JobTitleID == JobTitleID.Value);
        }
    if (DepartmentID.HasValue)
        {
            employees = employees.Where(j => j.DepartmentID == DepartmentID.Value);
        }
    return View(employees.ToList());
