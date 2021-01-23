    // This works quite well.
    // As a bonus it preserves the original input information 
    // and offers a navigatable/queryable hierarchy.
    var hierarchy = ItemHierarchy.BuildHierarchy(items);
    foreach (var item in hierarchy.OrderBy(r => r.NumberOfDescendents).ThenBy(r => r.OriginalInputOrder).SelectMany(r => r.Flattened))
        Console.WriteLine(item.ID);
