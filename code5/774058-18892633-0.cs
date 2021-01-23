            // do te transformation
            var employees =
              from employee in xml.Descendants("CompanyInfo").Elements("Employee")
              select new
              {
                  EmployeeName = employee.Attribute("name").Value,
                  EmployeeDeptId = employee.Attribute("deptId").Value,
                  Regions = from region in employee.Elements("Region")
                            select new
                                {
                                    Name = region.Attribute("name").Value,
                                    AreaCode = region.Element("Area").Attribute("code").Value,
                                }
              };
            // now do the filtering
            var filteredEmployees = from employee in employees
                                    from region in employee.Regions
                                    where region.AreaCode == "96"
                                    select employee;
