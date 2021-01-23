    using (Stream fileStream = File.OpenRead("path to your xml file"))
    {
        using (var reader = XmlReader.Create(fileStream))
        {
            while (reader.Read())
            {
                string enumerable = string.Join(string.Empty, Enumerable.Repeat(" ", reader.Depth));
                if (reader.NodeType == XmlNodeType.Element)
                {
                    Console.WriteLine(enumerable + reader.Name);
                }
                else if (reader.NodeType == XmlNodeType.Text)
                {
                    Console.WriteLine(enumerable + reader.Value);
                }
            }
        }
    }
