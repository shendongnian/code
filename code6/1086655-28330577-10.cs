    static string GetNameOf<T>(Expression<Func<T>> property)
    {
      var unary = property.Body as UnaryExpression;
      if (unary != null)
        return (unary.Operand as MemberExpression).Member.Name;
      return (property.Body as MemberExpression).Member.Name;
    }
