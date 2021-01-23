    var result = Machine
    .Join
    (
        MachineType,
        x=>x.MachineTypeID,
        x.MachineTypeID,
        (m,mt)=>new
        {
            m.MachineID,
            m.EmployeeID,
            m.Price,
            m.Make,
            m.Year,
            mt.Type
        }
    )
    .Join
    (
        Employee,
        x=>x.EmployeeID,
        x=>x.EmployeeID,
        (m,e)=>new 
        {
            m.MachineID,
            MachineType = m.Type,
            Employee = m.EmployeeName,
            m.Price,
            m.Make,
            m.Year
        }
     );
