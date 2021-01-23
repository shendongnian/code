    var result = context.Machines.Where(x => x.EmployeeID == 3)
                .Select(v => new 
                { 
                    v.MachineID, // from Machines table
                    v.MachineTypes.MachineType, // from MachineTypes table
                    v.Employees.EmployeeName, // from Employees table
                    v.Price, // from Machines table
                    v.Make, // from Machines table
                    v.Year // from Machines table
                });
