    public static void Compare<TComparate>(Expression<Func<TComparate, bool>> predicate)
    {
        if (predicate.Compile()((TComparate)comparatePerson)) return;
        var expression = (BinaryExpression)predicate.Body;
        var actual = Expression.Lambda(expression.Left, predicate.Parameters)
            .Compile().DynamicInvoke((TComparate)comparatePerson);
        var expected = Expression.Lambda(expression.Right, predicate.Parameters)
            .Compile().DynamicInvoke((TComparate)comparatePerson);
    }
