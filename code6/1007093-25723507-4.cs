    var element = XElement.Parse(yourXML);
    var result = element.Descendants("Organization")
    				.Select(org => new {
    					ID = org.Attribute("ID").Value,
    					Departments = org.Descendants("Department")
    					.Select(dept => new {
    						Name = dept.Attribute("Name").Value,
    						Employees = int.Parse(dept.Element("Employees").Value),
    						Building = dept.Element("Building").Value,
    						Obj = dept.Element("Obj").Value
    					})
    				})
    				.ToDictionary(
    					org => int.Parse(org.ID),
    					org => org.Departments.ToDictionary(dept => dept.Name));
