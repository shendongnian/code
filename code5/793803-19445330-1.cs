    foreach (var item in records)
    {
        string category = item.Description
                              .Split(new char[] { '|' })[1]
                              .Trim(new char[] { '[', ']');
    
        // this will give me the category for each item
        FieldItem fi = new FieldItem { Category = category }; // more items will be added
    
        if (!dict.Keys.Contains(category))
           dict.Add(category, new List<FieldItem>());
    
        dict[category].Add(fi);   
    }
