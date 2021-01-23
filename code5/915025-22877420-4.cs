    public enum OperatorComparer
    {
        Equals = ExpressionType.Equal,
        Contains,
        StartsWith,
        GreaterThan = ExpressionType.GreaterThan
    }
      var childProperty = parameter.Type.GetProperty(properties[0]);
        var left = Expression.Property(parameter, childProperty);
        var right = Expression.Constant(test, typeof(int));
        if(!new List<OperatorComparer>{OperatorComparer.Contains,OperatorComparar.StartsWith}.Contains(operatorComparer))
       {
            navigationPropertyPredicate = Expression.MakeBinary((ExpressionType)operatorComparer,left, right);
       }
       else
       {
          var method = GetMethod(value, operatorComparer); //get property by enum-name from type
          navigationPropertyPredicate = Expression.Call(left, method, right);
       }
        resultExpression = MakeLambda(parameter, navigationPropertyPredicate);
