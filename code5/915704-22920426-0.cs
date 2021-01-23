    var query = dbContext.Category.Select(u => new 
    { 
        Cat = u, 
        MovementCount = u.Movement.Count() 
    })
    .ToList()
    .OrderByDescending(u => u.MovementCount)
    .Select(u => u.Cat)
    .ToList();
