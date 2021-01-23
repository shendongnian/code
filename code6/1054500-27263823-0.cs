        List<studentRecord> studentCourses = new List<studentRecord>();
        XmlReader reader = xml.CreateReader();
        // Get elements
        while (reader.Read()) 
        {
            if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "Z_CRSE_DATA"))
            {
                reader.Read();
                if (reader.NodeType == XmlNodeType.Text)
                {
                    studentRecord stuRec = new studentRecord();
                    stuRec.rawData = reader.Value;
                    studentCourses.Add(stuRec);
                }
            }
        }
        reader.Close();
