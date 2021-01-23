    XDocument document = XDocument.Parse(xmlContent);
    string pcName = "esc02";
    IEnumerable<XElement> query =
        from pc in document.Element("PCs").Elements("PC")
        where pc.Element("pc_name").Value.Equals(pcName)
        select pc;
    XElement xe = query.FirstOrDefault();
    if (xe != null)
    {
        xe.Add(new XElement("user_name", "DMS"));
    }
    
