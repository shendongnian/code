    using (var db = new NorthwindDB())
            {
                var q = from c in db.Customers
                        select new
                        {
                            c.CompanyName,
                            EmployeeName = c.Orders.First().Employee.FirstName
                        };
            }
