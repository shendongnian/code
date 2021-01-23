    LambdaExpression GetLambdaExpression(Type type, IEnumerable<string> properties)
    {
      Type t = type;
      ParameterExpression parameter = Expression.Parameter(t);
      Expression expression = parameter;
      for (int i = 0; i < properties.Count(); i++)
      {
        expression = Expression.Property(expression, t, properties.ElementAt(i));
        t = expression.Type;
      }
            
      var lambdaExpression = Expression.Lambda(expression, parameter);
      return lambdaExpression;
    }
