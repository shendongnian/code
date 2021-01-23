    /// <summary>
    /// We need to find all Pop nodes, these are a member of the ExpressionStatement class.
    /// After we find a Pop statement (which ignores the current value on the stack), we will see if the value added
    /// to the stack is an instance MethodCall on an ImmutableType.
    /// </summary>
    /// <param name="statement"></param>
    public override void VisitExpressionStatement(ExpressionStatement statement)
    {
        if (statement == null) { throw new ArgumentNullException("statement"); }
        if (statement.Expression.NodeType == NodeType.Pop)
        {
            VisitUnaryExpression(statement.Expression as UnaryExpression);
        }
        base.VisitExpressionStatement(statement);
    }
    /// <summary>
    /// When we've found the UnaryExpression we check it for a MethodCall on an ImmutableType
    /// </summary>
    /// <param name="unaryExpression"></param>
    public override void VisitUnaryExpression(UnaryExpression unaryExpression)
    {
        if (unaryExpression == null) { throw new ArgumentNullException("unaryExpression"); }
        if (unaryExpression.NodeType == NodeType.Pop)
        {
            MethodCall call = unaryExpression.Operand as MethodCall;
            if (call != null)
            {
                MemberBinding binding = call.Callee as MemberBinding;
                if (binding.BoundMember.DeclaringType != null
                    && immutableTypes.Contains(binding.BoundMember.DeclaringType.FullName))
                {
                    Method method = binding.BoundMember as Method;
                    // If the method also returns an immutable Type we flag it as a problem.
                    if (immutableTypes.Contains(method.ReturnType.FullName))
                    {
                        this.Problems.Add(new Problem(GetResolution(), call));
                    }
                }
            }
        }
    }
