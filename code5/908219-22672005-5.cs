    public static IEnumerable<MemberInfo> ParameterAccesses<T, TResult>(
        Expression<Func<T, TResult>> lambda)
    {
        var visitor = new ParameterAccessesVisitor(lambda.Parameters);
        visitor.Visit(lambda);
        return visitor.VisitedMembers;
    }
