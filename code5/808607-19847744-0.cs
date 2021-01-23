    using LinqKit;
    Expression<Func<MyEntity, bool>> CreateExpression(SearchSpec search)
    {
        var predicate = PredicateBuilder.True<MyEntity>();
        if (search.Condition1.HasValue)
            predicate = predicate.And(e => e.SomeProperty == search.Condition1);
        if (search.Condition2.HasValue)
            predicate = predicate.And(e => e.OtherProperty == search.Condition2);
        ...
        return predicate;
    }
    
