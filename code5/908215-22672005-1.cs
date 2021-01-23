    public static IEnumerable<MemberInfo> ParameterAccesses(Expression expression)
    {
        var lambda = expression as LambdaExpression;
        if (lambda != null)
        {
            var visitor = new ParameterAccessesVisitor(lambda.Parameters);
            visitor.Visit(expression);
            return visitor.VisitedMembers;
        }
        return Enumerable.Empty<MemberInfo>();
    }
