    using (var reader = XmlReader.Create("test.xml"))
    {
        while (reader.Read())
        {
            if (reader.IsStartElement() && reader.Name == "Group")
            {
                // we are inside the Group element. We can now read its attributes
                string name = reader.GetAttribute("name");
                Console.WriteLine(name);
            }
        }
    }
