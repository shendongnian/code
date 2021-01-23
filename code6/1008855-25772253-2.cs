    @for(var i = 0; i < Model.Employees.Count; i++)
    {
      Html.Hiddenfor(m => m.Employees[i])
    }
    @for(var i = 0; i < Model.EmployeesInMultipleCompanies.Count; i++)
    {
      Html.Hiddenfor(m => m.EmployeesInMultipleCompanies[i])
    }
