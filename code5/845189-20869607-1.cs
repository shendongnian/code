    using (Stream fileStream = File.OpenRead("path to your xml file"))
    {
        using (var reader = XmlReader.Create(fileStream))
        {
            while (reader.Read())
            {
                string indent= string.Join(string.Empty, Enumerable.Repeat(" ", reader.Depth));
                if (reader.NodeType == XmlNodeType.Element)
                {
                    Console.WriteLine(indent+ reader.Name);
                }
                else if (reader.NodeType == XmlNodeType.Text)
                {
                    Console.WriteLine(indent+ reader.Value);
                }
            }
        }
    }
