    var events = pointsCore.Categories.SelectMany(c => c.Events);
    if (!string.IsNullOrEmpty(firstName))
    {
        events = events.Where(e => e.Firstname == firstName);
    }
    var result = events.Select(e => new { ... });
