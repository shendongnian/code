    private static List<Validated_Output> getDistinct(List<Validated_Output> validated)
    {
         var DistinctItems = validated
            .GroupBy(x => x.Date) // we group the Validated_Output by date
            .Select(g => 
                g.Select(vo => new Scored_Validated_Output(vo)) // in each group we score the Validated_Outputs
                .OrderByDescending(svo => svo.Score) // we order them by descending score
                .First() // keep only the first one (ie the highest score)
                .ValidatedOutput ) // and resolve it back to Validated_Output
            .ToList();
    
        return DistinctItems;
    }
