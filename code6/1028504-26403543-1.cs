     using (XmlWriter writer = XmlWriter.Create("employees.xml"))
        {
            writer.WriteStartDocument();
            writer.WriteStartElement("Employees");
        
            foreach (Employee employee in employees)
            {
        	writer.WriteStartElement("Employee");
        
        	writer.WriteElementString("ID", employee.Id.ToString());   // <-- These are new
        	writer.WriteElementString("FirstName", employee.FirstName);
        	writer.WriteElementString("LastName", employee.LastName);
        	writer.WriteElementString("Salary", employee.Salary.ToString());
        
        	writer.WriteEndElement();
            }
        
            writer.WriteEndElement();
            writer.WriteEndDocument();
        }
