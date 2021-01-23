    // Create a list of all items without children.
    var things = table.AsEnumerable()
                      .Select(row => new Thing
                      {
                          Id = row.Field<int>("Id"),
                          ParentId = row.Field<int>("ParentId")
                      })
                      .ToList();
    
    // Add children to each item.
    things.ForEach(t1 => t1.Children = things.Where(t2 => t2.ParentId == t1.Id).ToList());
    
    // Create a list of items that don't have a parent..
    things = things.Where(t => t.ParentId == 0).ToList();
