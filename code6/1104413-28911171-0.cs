    var topTen = people
        .SelectMany(r => r.Teams)          // Get the teams with duplicates
        .GroupBy(t => t)                   // Group by team
        .OrderByDescending(g => g.Count()) // Sort by count
        .Take(10)                          // Take top ten
        .Select(g => g.Key)                // Drop groups
        .ToList();                         // Make a list
