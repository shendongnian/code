    var members = db.Members; // Or .AsQueryable();
    if (!String.IsNullOrEmpty(searchString))
    {
        // Apply the conditional filter, returning Members
        members = members.Where(m => m.town == searchString);
    }
    // First of each member only (randomly)
    return View(members
                 .GroupBy(m => m.town)
                 .Select(grp => grp.First()));
