    // not sure what EList is though
    var items = db.EList.AsQueryable(); // or `IEnumerable<T>` ?
            
    if (title != null)
        items = items.Where(i => i.Title.Contains(title));
    var typesToFilter = new List<string>();
    if (Convert.ToBoolean(EtypeA))
        typesToFilter.Add("typeA");
    if (Convert.ToBoolean(EtypeB))
        typesToFilter.Add("typeB");
    if (typesToFilter.Count > 0)
        items = items.Where(i => typesToFilter.Any(i.EType.Contains));
    // this is where the provider will actually traverse the 
    // expression tree, convert it to SQL and execute it:    
    var results = items.ToList();
