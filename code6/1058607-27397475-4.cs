    var products = new List<Product>();
    products.Add(...);
    ...
            
    var nodes          = products.Select(p => new Node { Product = p }).ToList(); // 1
    var nodeWithId     = nodes.ToDictionary(n => n.Product.Id);                   // 2
    var parentChildren = nodes.Where(n => n.Product.ParentId != 0)
                              .ToLookup(n => nodeWithId[n.Product.ParentId]);     // 3
    foreach (var pc in parentChildren)  // 4
    {
        var parent   = pc.Key;
        var children = pc.ToList();
        parent.LstNodes = children;
    }
