    internal List<Apps> GetAllApps(string sortColumn)
    {
        List<Apps> employeeList = new List<Apps>();
        ...
        if (!string.IsNullOrEmpty(sortColumn))
        {
            employeeList = employeeList.AsQueryable<Apps>()
                                       .OrderBy(sortColumn)
                                       .Cast<Apps>()
                                       .ToList();
        }
        return employeeList;
