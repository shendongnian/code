    // First, Limit by 10
    var result = blogs
       .OrderByDescending(a => a.Created)
       .Where(a => a.Created >= DateTime.Now.Date).Take(10);
    // Get last max date:
    var lastDate = result.Max(a => a.Created);
    // Subsequent, Limit by 10
    var subsequentResult = blogs
       .OrderByDescending(a => a.Created)
       .Where(a => a.Created >= lastDate).Take(10);
    
    lastDate = subsequentResult.Max(a => a.Created);
