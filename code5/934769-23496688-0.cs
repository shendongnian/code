    using (XmlReader reader = XmlReader.Create("settings.xml"))
    {
        reader.MoveToContent();
        while(reader.Read())
        {
            if (reader.NodeType == XmlNodeType.Element)
            {
                Console.WriteLine("{0}: ",reader.Name);
                // Next read will contain text.
                if (reader.Read()) Console.WriteLine("{0}: ", reader.Value);
            }                    
        }                
    }
