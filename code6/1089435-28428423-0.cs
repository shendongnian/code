    var countsByType = animals.GroupBy(x => x.GetType(),
                                       (t, g) => new { Type = t, Count = g.Count() })
                              .ToList();
    // Could just use animals.Count, but this approach works for sequences
    // which can only be enumerated once.
    var totalCount = countsByType.Sum(t => t.Count);
    var proportions = countsByType.Select(pair => new { 
                                pair.Type,
                                Proportion = pair.Count / (double) totalCount
                            });
