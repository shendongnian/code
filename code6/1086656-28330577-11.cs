    using System.Linq.Expressions;
    //...
    static string GetNameOf<T>(Expression<Func<T>> property)
    {
      return (property.Body as MemberExpression).Member.Name;
    }
