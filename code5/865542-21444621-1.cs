    public bool IsPredicateGood(Expression<Func<CrossReferenceRelationshipEF, bool>> predicate)
    {
        var typedPredicate = (MethodCallExpression) predicate.Body;
        var innerPredicate = ((LambdaExpression)typedPredicate.Arguments[1]).Body;
        var dateArgument = ((BinaryExpression) innerPredicate).Right;
        return dateArgument != null; // not a real test yet, but you could adapt
    }
