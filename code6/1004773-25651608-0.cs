    using(var ctx = new Database())
    {
        return (from o in ctx.Orders
            join po in ctx.ProductOrder on o.OrderID equals po.OrderID
            into products
            where o.OrderID == 1
            select new OrderDTO
                {
                    OrderID = o.OrderID,
                    OrderDate = o.OrderDate,
                    EmployeID = o.EmployeeID,
    
                    Products = products.Select(po => new ProductDTO
                    {
                        ProductID = po.ProductID,
                        Name =  po.Name
                    }).ToList();
                }).ToList();
    }
