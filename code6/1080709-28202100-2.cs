    foreach (string path in file.Paths)
    {
        XmlNode node = doc.SelectSingleNode(path);
        if (node.Attributes["type"].Value == "system" && node.Attributes["type"].Value != null)
        {
            node.Attributes["type"].Value = "session";
        }
    }
    //push to DB
