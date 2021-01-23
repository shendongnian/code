    var employees = (from e in xml.Root.Elements("Employee")
                     select new Employee
                     {
                         EmployeeName = (string)e.Attribute("employee"),
                         DeptId = (string)e.Attribute("deptId"),
                         RegionList = e.Elements("Region")
                                       .Select(r => new Region {
                                           RegionName = (string)r.Attribute("name"),
                                           AreaCode = (string)r.Element("Area").Attribute("code")
                                       }).ToList()
                     }).ToList();
