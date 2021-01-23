    public static class ObjectExtensions {
      public static TAttribute GetAttribute<T, TAttribute, TProperty>(this T instance, 
        Expression<Func<T, TProperty>> selector) {
          var member = selector.Body as MemberExpression;
          if (member != null) {
            return member.Member.GetCustomAttributes(typeof(TAttribute)).FirstOrDefault() as T;
          }
          return null;
      }
    }
