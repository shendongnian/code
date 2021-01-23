    var res1 = nwd.Orders //response
    if (sort != "OrderID")
      {
          if (sort == "EmployeeName")
          {
             res1 = res1.OrderBy(o => o.Employee.FirstName);
         }
         else
         {
             res1 = res1.OrderBy(o => o.Customer.CompanyName);
         }
      }
    res1 = res1.ThenBy(o => o.OrderID)
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
