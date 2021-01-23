              var employees2 =
              from selectedEmployee2 in
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
                  }
              from region in selectedEmployee2.Regions
              where region.AreaCode == "96"
              select selectedEmployee2;
