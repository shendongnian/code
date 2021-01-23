     var employeeTypes = from t in DbContext.Set<SetupEmployeeType>().AsNoTracking()
                                    join empg in
                                        (
                                            from emp in DbContext.Set<Employee>().AsNoTracking()
                                            group emp by emp.EmployeeTypeId into g
                                            select new { EmployeeTypeId = g.Key, Total = g.Count() }
                                        ) on t.EmployeeTypeId equals empg.EmployeeTypeId into employee
                                    from subemp in employee.DefaultIfEmpty()
                                    where t.MasterEntity == masterEntity
    
                                    select new Model.SetupEmployeeTypeModel()
                                    {
                                        EmployeeTypeId = t.EmployeeTypeId,
                                        Description = t.Description,
                                        AllowProbation = t.AllowProbation,
                                        IsActive = t.IsActive,
                                        TotalEmployee = subemp.Total 
    
                                    };
