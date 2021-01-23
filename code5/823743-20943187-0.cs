        Expression ParseAggregate(Expression instance, Type elementType, string methodName, int errorPos)
        {
            ...
            Type[] typeArgs;
            if (signature.Name == "Min" || signature.Name == "Max")
            {
                typeArgs = new Type[] { elementType, args[0].Type };
            }
            else if(signature.Name == "Select")
            {
                typeArgs = new Type[] { elementType, Expression.Lambda(args[0], innerIt).Body.Type };
            } 
            else if(signature.Name == "SelectMany")
            {
                var type = Expression.Lambda(args[0], innerIt).Body.Type;
                var interfaces = type.GetInterfaces().Union(new[] { type });
                Type resultType = interfaces.Single(a => a.Name == typeof(IEnumerable<>).Name).GetGenericArguments()[0];
                typeArgs = new Type[] { elementType, resultType };
            }
            else
            {
                typeArgs = new Type[] { elementType };
            }
            ...
        }
       
