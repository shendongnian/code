    private Expression<Func<IHaveNoteRemarkSubject, bool>> DynamicMustFilterWhere(IEnumerable<string> exactFilterValues, string propertyName)
    {
        //Build the individual filters for each filter value
        var individualFilters =
            exactFilterValues.Select(
            //The PredicateBuilder.Make method is very handy in building dynamic filters.  In this case, we are dynamically 
            //  specifying the property name to do the Contains on
                str => PredicateBuilder.Make(typeof (IHaveNoteRemarkSubject), propertyName, FilterOperator.Contains, str));
        //AND all the individual filters together
        var combined = PredicateBuilder.And(individualFilters.ToArray<IPredicateDescription>());
        //Much of DevForce can use Predicate directly.  But if we want to end up with an Expression<Func<...>>, we can do that...
        //Have DevForce build the predicate into a lambda expression
        var lambda = combined.ToLambdaExpression();
        //Then we can cast the lambda to the Expression<Fun<...>> type
        return (Expression<Func<IHaveNoteRemarkSubject, bool>>) lambda;
    }
