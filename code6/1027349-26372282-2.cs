    var res1 = nwd.Orders //response
    IOrderedQueryable<Orders> result;
    if (sort != "OrderID")
    {
        if (sort == "EmployeeName")
        {
            result = res1.OrderBy(o => o.Employee.FirstName);
        }
        else
        {
            result= res1.OrderBy(o => o.Customer.CompanyName);
        }
    }
    result = result.ThenBy(o => o.OrderID)
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
