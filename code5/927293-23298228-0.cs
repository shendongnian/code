    //this is the list with combinations 
    //---------------------------\/
    List<sortedEmployeeClass> sortedList = new List<sortedEmployeeClass>();
    
    foreach (var employee in employeeList)
    {
       foreach(var department in employee.DeptList)
       {
          foreach(var area in employee.AreaList)
          {
              sortedEmployeeClass sorted = new sortedEmployeeClass();
              sorted.EId = employee.EId;
              sorted.EName = employee.EName;
              sorted.DepartmentName = department.Name;
              sorted.AreaName = area.AreaName;
              sortedList.Add(sorted);
          }
       }
    }
