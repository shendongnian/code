     private string GetPropertyName(Expression<Func<T>> propertyExpession)
     {
       //the cast will always succeed if properly used
       MemberExpression memberExpression = (MemberExpression)propertyExpression.Body;
       string propertyName = memberExpression.Member.Name;
       return propertyName;
     }
