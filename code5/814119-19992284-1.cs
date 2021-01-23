    public DirectoryEntry CreateDataModelFromXml(Stream xmlFileStream)
    {
        XDocument xDoc = XDocument.Load(xmlFileStream);
        return new DirectoryEntry(QueryChildEntries(xDoc.Element("Folder")))
        {
            Name = "ROOT"
        };
    }
    private IEnumerable<NamedTreeEntry> QueryChildEntries(XElement xElem)
    {
        return
            from childElem in xElem.Elements()
            where childElem.Name == "dir" || childElem.Name == "file"
            select
            (childElem.Name == "file") ? (NamedTreeEntry) new FileEntry()
            {
                Name = childElem.Element("name").Value
            }
            : new DirectoryEntry(QueryChildEntries(childElem))
            {
                Name = childElem.Element("name").Value,
            };
    }
