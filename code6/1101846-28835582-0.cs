    internal List<Employee> ReadEmployees()
    {
    	List<Employee> employees = new List<Employee>();
    
    	string fileName = "XMLFile1.xml";
    	if (File.Exists(fileName))
    	{
    		XDocument document = XDocument.Load(fileName);
    		if (document.Root != null)
    		{
    			foreach (XElement infoElement in document.Root.Elements("info"))
    			{
    				Employee employee = new Employee();
    
    				XElement ageElement = infoElement.Element("age");
    				XElement sexElement = infoElement.Element("sex");
    				XElement idElement = infoElement.Element("id");
    				XElement nameElement = infoElement.Element("name");
    
    				if (ageElement != null)
    					employee.Age = ageElement.Value;
    				if (sexElement != null)
    					employee.Sex = sexElement.Value;
    				if (idElement != null)
    					employee.Id = idElement.Value;
    
    				if (nameElement != null)
    				{
    					var firstnameElement = nameElement.Element("first");
    					var lastnameElement = nameElement.Element("last");
    					if (firstnameElement != null)
    						employee.Firstname = firstnameElement.Value;
    					if (lastnameElement != null)
    						employee.Lastname = lastnameElement.Value;
    				}
    				employees.Add(employee);
    			}
    		}
    	}
    	return employees;
    }
