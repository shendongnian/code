    public ProjectionList GetSharedProjections()
    {
        Coffee coffee = null;
        TargetDTO target;
        var projections = Projections.ProjectionList()
            .Add(Projections.Property(() => coffee.CoffeeName)
                .WithAlias(() => target.CoffeeName));
   
        return projections;
    }
