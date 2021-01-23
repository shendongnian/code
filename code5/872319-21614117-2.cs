    public static Expression<Func<T, bool>> BuildPredicateForFilter<T>(string filterString)
            {
                //first, split search by space, removing white spaces, and putting this to upper case
                var filters = filterString.Split(new []{" "}, StringSplitOptions.RemoveEmptyEntries).Select(m => m.ToUpper());
                var parameter = Expression.Parameter(typeof (T), "m");
                
                //get string.Contains() method
                var containsMethod = typeof (string).GetMethod("Contains");
                //get string.ToUpper() method
                var toUpperMethod = typeof (string).GetMethod("ToUpper", new Type[]{});
                //find all the string properties of your class
                var properties = typeof(T).GetProperties().Where(m => m.PropertyType == typeof(string));
                //for all the string properties, build a "m.<PropertyName>.ToUpper() expression
                var members = properties.Select(p => Expression.Call(Expression.Property(parameter, p), toUpperMethod));
                Expression orExpression = null;
                //build the expression
                foreach (var filter in filters)
                {
                    Expression innerExpression = null;
                    foreach (var member in members)
                    {
                        innerExpression = innerExpression == null
                            ? (Expression)Expression.Call(member, containsMethod, Expression.Constant(filter))
                            : Expression.OrElse(innerExpression, Expression.Call(member, containsMethod, Expression.Constant(filter)));
                    }
                    orExpression = orExpression == null
                        ? innerExpression
                        : Expression.AndAlso(orExpression, innerExpression);
                }
                return Expression.Lambda<Func<T, bool>>(orExpression, new[]{parameter});
                
            }
