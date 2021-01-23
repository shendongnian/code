      public static IQueryable<TClass> AsQueryable<TClass>(this TClass obj, params Expression<Func<TClass, object>>[] propertyExpressions)
        {
            foreach (var propertyExpression in propertyExpressions)
            {
                MemberExpression memberExpression = propertyExpression.Body as MemberExpression;
                if (memberExpression == null)
                {
                    // this is needed for value types properties.
                    UnaryExpression unaryExpression = (UnaryExpression)propertyExpression.Body;
                    memberExpression = unaryExpression.Operand as MemberExpression;
                }
                if (memberExpression == null)
                    throw new ArgumentException(string.Format("Expression '{0}' is not a member expression.", propertyExpression.ToString()));
                PropertyInfo propertyInfo = memberExpression.Member as PropertyInfo;
                if (propertyInfo == null)
                    throw new ArgumentException("MemberExpression.Member is not a PropertyInfo.");
                // at this point we have PropertyInfo which you can use with your OR Mapper to further implement logic which will eager load the property
                // e.g. property name can be retrieved with:
                string propertyName = propertyInfo.Name;
                // do your ORM stuff here
            }
        }
