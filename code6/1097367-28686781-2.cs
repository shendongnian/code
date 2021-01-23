    public ProjectionList GetSharedProjection(Expression<Func<Coffee>> coffeeAlias)
    {
        TargetDTO target = null; 
 
        var projections = Projections.ProjectionList()
            .Add(BuildProjection<Coffee>(coffeeAlias, c => c.CoffeeName))
                .WithAlias(() => target.CoffeeName);
    }
