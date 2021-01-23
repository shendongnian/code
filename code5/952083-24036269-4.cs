     Data = (from emp in db.Employees
                select new
                {
                 EId = emp.EId ,
                 EmployeeName = emp.EmployeeName
                })
                .AsEnumerable()
                .OrderBy(i => i.GetType().GetProperty(colName).GetValue(i, null))
                .ToList();
