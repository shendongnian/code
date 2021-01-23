    public void AddTagToXml(string path, string tag)
    {
        XDocument doc;
        // Load the existing file
        if (File.Exists(path)) doc = XDocument.Load(path);
        else
        {
            // Create a new file with the parent node
            doc = new XDocument(new XElement("Tags"));
        }
        doc.Root.Add(new XElement("tag", tag));
        doc.Save(path);
    }
