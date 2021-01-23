    case FilterOperator.Contains:
        // if collection
        if (propertyExpression.Type.IsGenericType &&
            typeof(IEnumerable<>)
                .MakeGenericType(propertyExpression.Type.GetGenericArguments())
                .IsAssignableFrom(propertyExpression.Type))
        {
            // find AsQueryable method
            var toQueryable = typeof(Queryable).GetMethods()
                .Where(m => m.Name == "AsQueryable")
                .Single(m => m.IsGenericMethod)
                .MakeGenericMethod(typeof(string));
            // find Any method
            var method = typeof(Queryable).GetMethods()
                .Where(m => m.Name == "Any")
                .Single(m => m.GetParameters().Length == 2)
                .MakeGenericMethod(typeof(string));
            // make expression
            condition = Expression.Call(
                null, 
                method,
                Expression.Call(null, toQueryable, propertyExpression), 
                filterCriteria.Expression
            );
        }
        else
        {
            condition = Expression.Call(propertyExpression, typeof(string).GetMethod("Contains", new[] { typeof(string) }), valueExpression);
        }
        break;
