    select new Employee
                      {
                         Name = emp1.Name,
                         Id = emp1.Id,
                         BasicSalary = emp1.BasicSalary,
                         HRA = emp1.HRA,
                         DA = emp1.DA,
                         TotalSalary = emp2.TotalSalary
                      });
    return Query.ToList();
