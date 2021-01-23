        var contractorViewModel = from x in PersonAndTaxHelper.GetContratorAndTax(context.Contractors)
                                select new
                                {
                                    x.Entity.Name,
                                    x.Entity.BusinessName
                                    x.Tax,
                                };
        var employeeViewModel = from x in PersonAndTaxHelper.GetEmployeeAndTax(context.Employees)
                                select new
                                {
                                    x.Entity.Name,
                                    x.Entity.YearsOfService
                                    x.Tax,
                                };
   
