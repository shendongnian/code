    var doc = XDocument.Load("path_to_xml_file.xml");
    Dictionary<string, int[]> dictionary = new Dictionary<string, int[]>();
    foreach (var key in doc.Root.Elements("key"))
    {
        dictionary.Add((string)key.Attribute("value"), key.Elements("Index").Select(o => int.Parse((string)o)).ToArray());
    }
