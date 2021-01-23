        var query = (
            //Customers
            from customer in context.Customers
            //Engineer 1
            join engineer1 in context.Employees on customer.PrimaryEngineer equals
            engineer1.EmployeeId into eng1 
            from engineer1 in eng1.DefaultIfEmpty()
            //Engineer Top
            join engineerTop in context.Employees on customer.TopEngineer equals 
            engineerTop.EmployeeId into top
            from engineerTop in top.DefaultIfEmpty()
            group new {customer, engineer1, engineerTop} by new {CustName = customer.Name, EmpId1 = engineer1.EmployeeId, EmpId2 = engineerTop.EmployeeId} into grp
            select new
            {
                Name = grp.Key.CustName,
                EmpId1 = grp.Key.EmpId1,
                EmpId2 = grp.Key.EmpId2
            });
