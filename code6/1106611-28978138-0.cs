    [__DynamicallyInvokable]
    public static MethodCallExpression Call(Expression instance, MethodInfo method, IEnumerable<Expression> arguments)
    {
      ContractUtils.RequiresNotNull((object) method, "method");
      ReadOnlyCollection<Expression> arguments1 = CollectionExtensions.ToReadOnly<Expression>(arguments);
      Expression.ValidateMethodInfo(method);
      Expression.ValidateStaticOrInstanceMethod(instance, method);
      Expression.ValidateArgumentTypes((MethodBase) method, ExpressionType.Call, ref arguments1);
      if (instance == null)
        return (MethodCallExpression) new MethodCallExpressionN(method, (IList<Expression>) arguments1);
      return (MethodCallExpression) new InstanceMethodCallExpressionN(method, instance, (IList<Expression>) arguments1);
    }
