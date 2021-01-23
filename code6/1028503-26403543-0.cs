    using (XmlWriter writer = XmlWriter.Create("employees.xml"))
    {
        writer.WriteStartDocument();
        writer.WriteStartElement("Employees");
    
        foreach (Employee employee in employees)  // <-- This is new
        {
    	writer.WriteStartElement("Employee"); // <-- Write employee element
    	writer.WriteEndElement();
        }
    
        writer.WriteEndElement();
        writer.WriteEndDocument();
    }
