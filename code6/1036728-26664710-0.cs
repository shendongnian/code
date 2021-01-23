    using (XmlReader xmlReader = XmlReader.Create(zdPath))
    {
        xmlReader.MoveToContent();
        while(xmlReader.Read())
        {
            if(xmlReader.IsStartElement())
            {
                switch (xmlReader.Name.ToLower())
                {
                    case "machinename":
                        xmlReader.Read();
                        string clientName = xmlReader.Value;
                        Console.WriteLine(xmlReader.Value);
                        break;
                    case "rolename":
                        xmlReader.Read();
                        string role = xmlReader.Value;
                        if (role == "Admin")
                        {
                         Console.WriteLine(xmlReader.Value);
                        }
                    break;
                }
            }
        }
    }
