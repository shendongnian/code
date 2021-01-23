    var q = from empType in DbContext.Set<SetupEmployeeType>().AsNoTracking()
        	join empCnt in 
        		(
        			from emp in DbContext.Set<Employee>().AsNoTracking()
        			group emp by emp.EmployeeTypeId into grp
        			select new { EmployeeTypeId = grp.Key, TotalEmp = grp.Count()}
        		) on empType.EmployeeTypeId equals empCnt.EmployeeTypeId into employees
        	from subemp in employees.DefaultIfEmpty()
        	where t.MasterEntity == masterEntity
        	select new Model.SetupEmployeeTypeModel()
            {
                EmployeeTypeId = empType.EmployeeTypeId,
                Description = empType.Description,
                AllowProbation = empType.AllowProbation,
                IsActive = empType.IsActive,
                TotalEmployee = subemp.TotalEmp
            };
