           select new Employee
           {
               EmployeeName = employee.Attribute("name").Value,
               EmployeeDeptId = employee.Attribute("deptId").Value,
               //RegionName = employee.Element("Region").Attribute("name").Value,
               //AreaCode = employee.Element("Region").Element("Area").Attribute("code").Value,
               Regions = (from r in employee.Elements("Region") select new Region 
                          {
                             Name = r.Attribute("name").Value,
                             Code = r.Element("Area").Attribute("code").Value,
                          }).ToList();
           }
