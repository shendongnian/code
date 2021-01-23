    public static object AggregateFunc(this IQueryable source, string function, string member)
    {
            if (source == null) throw new ArgumentNullException("source");
            if (member == null) throw new ArgumentNullException("member");
            // Properties
            PropertyInfo property = source.ElementType.GetProperty(member);
            ParameterExpression parameter = Expression.Parameter(source.ElementType, "s");
            
            // We've tried to find an expression of the type Expression<Func<TSource, TAcc>>,
            // which is expressed as ( (TSource s) => s.Price );
            Type propertyType = property.PropertyType;
            Type convertPropType = property.PropertyType;
            if (function == "Sum")//convert int to bigint
            {
                if (propertyType == typeof(Int32))
                    convertPropType = typeof(Int64);
                else if (propertyType == typeof(Int32?))
                    convertPropType = typeof(Int64?);
            }
            Expression selector = Expression.Lambda(Expression.Convert(Expression.MakeMemberAccess(parameter, property), convertPropType), parameter);
            //var methods = typeof(Queryable).GetMethods().Where(x => x.Name == function);
            // Method
            MethodInfo aggregateMethod = typeof(Queryable).GetMethods().SingleOrDefault(
                m => m.Name == function
                    && m.IsGenericMethod
                    && m.GetParameters().Length == 2 && m.GetParameters()[1].ParameterType.GenericTypeArguments[0].GenericTypeArguments[1] == convertPropType);// very hacky but works :)
            MethodCallExpression callExpr;
            // Sum, Average
            if (aggregateMethod != null)
            {
                callExpr = Expression.Call(
                        null,
                        aggregateMethod.MakeGenericMethod(new[] { source.ElementType }),
                        new[] { source.Expression, Expression.Quote(selector) });
                return source.Provider.Execute(callExpr);
            }
            // Min, Max
            else
            {
                aggregateMethod = typeof(Queryable).GetMethods().SingleOrDefault(
                    m => m.Name == function
                        && m.GetGenericArguments().Length == 2
                        && m.IsGenericMethod);
                if (aggregateMethod != null)
                {
                    callExpr = Expression.Call(
                        null,
                        aggregateMethod.MakeGenericMethod(new[] { source.ElementType, propertyType }),
                        new[] { source.Expression, Expression.Quote(selector) });
                    return source.Provider.Execute(callExpr);
                }                
            }
            return null;
        }
