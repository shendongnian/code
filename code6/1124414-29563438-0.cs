    ViewBag.Employees = _employeeRepository
    .GetAll()
    .Select(x => new SelectListItem
    {
         Text = x.LastName,
         Value = x.ID.ToString(),
         Selected = employeeToClientContract.EmployeeID == x.ID
    }); 
