    var temp_list = new List<Orders>();
    if (sort != "OrderID")
    {
        if (sort == "EmployeeName")
        {
            sort = "Employee.FirstName"; //sort by Employee FirstName
            temp_list = nwd.Orders //response
                .OrderBy(o => o.Employee.FirstName);
        }
        else
        {
            temp_list = nwd.Orders //response
               .OrderBy(o =>  o.Customer.CompanyName);
        }
    }
    // temp_list is already ordered by what you want
    var res1 = temp_list.OrderBy(o => o.OrderID)
        
       .Skip((page - 1) * rowsPerPage)
      .Take(rowsPerPage)
       .Select(o => new
       {
           o.OrderID,
           o.Customer.CompanyName,
           o.Customer.ContactName,
           o.Employee.FirstName,
           o.Employee.LastName,
           o.Order_Details
       }).ToList();
