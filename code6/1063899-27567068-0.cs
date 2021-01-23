    private bool ContainsEntity(FileInfo filePath, string entityType, int id, string field, string value)
    {
        try{
        var doc = XDocument.Load(filePath.FullName);
        var entities = doc.Descendants(entityType);
		XNamespace ns = "http://schemas.sage.com/sdata/2008/1";
		XName name = ns + "uuid";
		var specificEntities = entities.Where(y => y.Attribute(name).Value.Equals(id));
		return specificEntities.Any(ent =>
            ent.Elements(field).Any(f => f.Value.Equals(value, StringComparison.OrdinalIgnoreCase)));
        }catch{return false;}
    }
