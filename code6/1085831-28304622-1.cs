    xml.WriteStartDocument();
    xml.WriteStartElement("userProfiles");
    xml.WriteElementString("groupId", "1");
    
    foreach (var profile in profiles)
    {
        xml.WriteStartElement("profile");
        xml.WriteElementString("name", "test 1");
        xml.WriteElementString("id", "10000");
        xml.WriteStartElement("userPerformance");
        xml.WriteElementString("type", "yearly");
        // assume that I have the proper allDays as a List of DateTime
        foreach (var days in allDays)
        {
            // What will be my StartElement?
            xml.WriteStartElement("values");
            xml.WriteElementString("start", DateTime.Now.ToString());
            xml.WriteElementString("end", DateTime.Now.ToString());
            xml.WriteElementString("value", "0815");
            xml.WriteEndElement();
        }
        xml.WriteEndElement();
        xml.WriteEndElement();
    }
    xml.WriteEndElement();
