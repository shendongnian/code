    var bestSponsors = projects.SelectMany(p => p.Sponsors)
        .GroupBy(p => p.Name)
        .OrderByDescending(g => g.ToList().Count)
        .Select(p => new
               {
                   Name = p.Key,
                   SponsoredProjectCount = p.ToList().Count
               })
        .ToList();
