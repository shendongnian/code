    public static class LinqExtensions
    {
       public static Expression<Func<T, bool>> False<T>() { return f => false; } 
       public static Expression<Func<T, bool>> In<T, TValue>(this Expression<Func<T, bool>> predicate,string propertyName, List<TValue> values)
       {            
               var param = predicate.Parameters.Single();
               MemberExpression property = Expression.PropertyOrField(param, propertyName);            
               var micontain = typeof(List<TValue>).GetMethod("Contains");            
               var mc = Expression.Call(Expression.Constant(values), micontain, property);
               return Expression.Lambda<Func<T, bool>>(mc, param);
       }
    }
