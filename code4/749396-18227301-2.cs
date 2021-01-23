    public class MyContext : DbContext
    {
        public bool IsDatabaseGeneratedProperty<TSource>(Expression<Func<TSource, object>> propertyExpression)
        {
            var property = GetPropertyInfo(propertyExpression);
            var attribute = property.GetCustomAttribute<GeneratedByDatabaseAttribute>();
            return attribute != null;
        }
    
        public PropertyInfo GetPropertyInfo<TSource>(Expression<Func<TSource, object>> propertyLambda)
        {
            var member = propertyLambda.Body as MemberExpression;
            if (member == null)
            {
                var ubody = (UnaryExpression)propertyLambda.Body;
                member = ubody.Operand as MemberExpression;
            }
            return member.Member as PropertyInfo;
        }
    }
