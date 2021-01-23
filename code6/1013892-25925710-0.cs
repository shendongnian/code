    var q = _context.Employee.Where(p => employeeEMIIDs.Contains(p.EmployeeID))
        .Select(p => new
        {
            Employee = new EmployeeDTO
            {
                 EmployeeID = p.EmployeeID,
                 GenderTypeID = p.GenderTypeID,
                 FirstName = p.FirstName,
                 LastName = p.LastName,
                 Name = p.Name,
                 MiddleName = p.MiddleName,
                 DOB = p.DOB,
                 Suffix = p.Suffix,
                 Title = p.Title
             },
             Specialty = p.EmployeeSpecialty
                 .Select(d => new 
                 {
                     d.OrganizationSpecialtyType.SpecialtyTypeID,
                     d.OrganizationSpecialtyType.Name
                 })
        })                    
        .AsEnumerable()
        .Select(a => 
        {
            a.Employee.Specialty = a.Specialty
                .ToDictionary(d => d.SpecialtyTypeID, d => d.Name);
            return a.Employee;
        });
                    
