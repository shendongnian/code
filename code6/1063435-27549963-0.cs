    private static System.Func<object, object> BuildAccessor(FieldInfo field)
    {
      ParameterExpression obj = Expression.Parameter(typeof(object), "obj");
      UnaryExpression instance = !field.IsStatic ? Expression.Convert(obj, field.DeclaringType) : null;
      Expression<System.Func<object, object>> expr = Expression.Lambda<System.Func<object, object>>(
        Expression.Convert(
          Expression.Field(instance, field),
          typeof(object)),
        obj);
      return expr.Compile();
    }
