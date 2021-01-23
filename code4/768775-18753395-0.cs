    var parts = title.Split('/');
    var categories = db.Categories
        .Where(c => parts.Contains(c.Title))
        .ToList();
    // start at the root
    var category = categories.Where(c => c.ParentId == null && c.Title == parts[0]);
    // look for anything past the root level (starting at index 1 not 0)
    for (var i = 1; i < parts.Length; i++)
    {
        category = categories.Where(c => c.ParentId == category.Id && c.Title == parts[i]);
    }
    // use category to create new view
    return View(category);
