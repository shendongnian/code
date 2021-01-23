    public static IQueryable<T> Intersect<T>(this IQueryable<T> source, string property, IEnumerable<int> value)
            {
                var type = typeof(T);
                var _value = Expression.Constant(value); //List of ids
                //Declare parameter for outer lambda
                ParameterExpression param = Expression.Parameter(type, "x");
    
                //Outer Lambda
                Expression expr = param;
                foreach (string prop in property.Split('.')) //Dig for deep property
                {
                    PropertyInfo pi = type.GetProperty(prop);
                    expr = Expression.Property(expr, pi);
                    type = pi.PropertyType;
                }
    
                //Get deep property's type
                var enumtype = type.GetGenericArguments()[0];
                //Declare parameter for inner lambda
                ParameterExpression tpe = Expression.Parameter(enumtype, "y");
    
                //Inner Collection lambda logic
                //Property for inner lambda
                Expression propExp = Expression.Property(tpe, enumtype.GetProperty("Id"));
                //Contains method call .Contains(y.Id)
                var containsMethodExp = Expression.Call(typeof(Enumerable), "Contains", new[] { propExp.Type }, _value, propExp);
                //Create Expression<Func<enumtype, bool>>
                var innerDelegateType = typeof(Func<,>).MakeGenericType(enumtype, typeof(bool));
                //Create Inner lambda y => _vals.Contains(y.Id)
                var innerFunction = Expression.Lambda(innerDelegateType, containsMethodExp, tpe);
                //Get Any method info
                var anyMethod = typeof(Enumerable).GetMethods().Where(m => m.Name == "Any" && m.GetParameters().Length == 2).Single().MakeGenericMethod(enumtype);
                //Call Any with inner function .Any(y => _vals.Contains(y.Id))
                var outerFunction = Expression.Call(anyMethod, expr, innerFunction);
                //Call Where
                MethodCallExpression whereCallExpression = Expression.Call
                (
                    typeof(Queryable),
                    "Where",
                    new Type[] { source.ElementType },
                    source.Expression,
                    Expression.Lambda<Func<T, bool>>(outerFunction, new ParameterExpression[] { param })
                );
                //Create and return query
                return source.Provider.CreateQuery<T>(whereCallExpression);
            }
