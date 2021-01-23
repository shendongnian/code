    context.Candy
        .Select(c => c.CandyRegion
            .OrderByDescending(cr => 
                /* 
                 * Order CandyRegion by Candy.CandyRegion.Count outside
                 * the context of c? 
                 */
                c.CandyRegion.Count()
            )
            .FirstOrDefault()
        )
        .ToList();
