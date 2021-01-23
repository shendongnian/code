       var result = risksObjects.GroupBy(g => new { g.Product, g.Level1, g.Level2 } )
                        .Select(
                            g => new { 
                                Key = g.Key,
                                Total = g.Sum(r => r.Risk)
                            }
                        )
                        .ToArray();
