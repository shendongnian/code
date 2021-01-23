    private Expression<Func<StructureAnalysis, bool>> Query(StructureAnalysis structureAnalysis)
    {
        var query = PredicateBuilder.True<StructureAnalysis>();
        query = query.And(analysis =>
                // The names match
                analysis.Name == structureAnalysis.Name &&
                // We have the same # of goals so they must all match.
                analysis.Goals.Count == structureAnalysis.Goals.Count
            );
        return query;
    }
