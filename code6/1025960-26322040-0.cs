    var list = from o in ordersList
                join cl in customersList
                on o.CustomerID equals cl.CustomerID
                join ol in orderDetailsList
                on o.OrderID equals ol.OrderID
                join e in employeeList
                on o.EmployeeID equals e.EmployeeID
                select new
                {
                    o.OrderID,
                    cl.CompanyName,
                    cl.ContactName,
                    EmployeeName = e.FirstName + " " +e.LastName,
                    ol.Quantity,
                    ol.UnitPrice
                };
    var result =  list.GroupBy(x => x.OrderID).Select(g => new
    {
        OrderID = g.Key,
        CompanyName = g.First().CompanyName,
        ContactName = g.First().ContactName,
        EmployeeName = g.First().EmployeeName,
        TotalQuantity = g.Sum(x => x.Quantity),
        TatalPrice = g.Sum(x => x.Quantity * x.UnitPrice)
    });
