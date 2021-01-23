    static class HelperClass {
      static Expression<Func<T,object>> GroupByExpression<T>(string propertyName) {
        var parameter = Expression.Parameter(typeof(T),"x");
        var body =  Expression.Property(parameter,propertyName);
        return Expression.Lambda<Func<T,object>>(Expression.Convert(body, typeof(object)), parameter);
      }
    }
