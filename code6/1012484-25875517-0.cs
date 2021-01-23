    .Select(department => CreateDepartment(department["Name"].ToString(), employeesResult))
    ...
    static Department CreateDepartment(string name, IEnumerable<Employee> employees)
    {
      var department = new Department()
      {
        Name = name
      };
      foreach (var employee in employees)
      {
        department.Employees.Add(employee);
      }
      return department;
    }
