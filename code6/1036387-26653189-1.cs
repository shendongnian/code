    // Consider ID as the key (maybe int in your case) and GenericProperty as a class of just 2 properties: name of property and value.
    List<YourClass> list;
    Dictionary<ID, HashSet<GenericProperty>> dict = ConvertToDictionary(list); // Convert the list to a dictionary
    // Aggregate values per ID (key)
    // You can get the PropertyName with reflection
    
    foreach (var pair in dict)
    {
        var row = DataTable.Rows.AddRow();
        foreach (var values in pair.Value)
            row[pair.Value.PropertyName] = pair.Value.Value;
    }
    
