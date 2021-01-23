    List<MYLIST> assm = Utilities.LoadEntityInstances<VMYLIST>()
    List<Employee> employees = new List<Employee>();
    foreach (var item in assm)
    {
        // if this element was not added before
        if (employees.All(x => x.Name != item.EmployeeName && x.EmployeeNumber != item.EmployeeNumber))
            employees.Add(new Employee { Name = item.EmployeeName, EmployeeNumber = item.EmployeeNumber, LaborTypeName = item.LaborTypeName, SysId = item.Employee });
    }
