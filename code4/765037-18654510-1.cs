    using (XmlWriter writer = XmlWriter.Create("Student.xml"))
	{
	    writer.WriteStartDocument();
	    writer.WriteStartElement("Students");
	    foreach (Student student in StudentList)
	    {
		writer.WriteStartElement("Student");
		writer.WriteElementString("id", student.ID.ToString());
		writer.WriteElementString("name", student.Name.ToString());
		writer.WriteElementString("number", student.Number.ToString());
		writer.WriteElementString("email", student.Email.ToString());
		writer.WriteEndElement();
	    }
	    writer.WriteEndElement();
	    writer.WriteEndDocument();
	}
