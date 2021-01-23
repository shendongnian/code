    public static IQueryable SelectByFields(this IQueryable q, string expression, params object[] values) // IEnumerable<string> fieldNames)
        {
            try
            {
                if (q == null)
                    throw new ArgumentNullException("source");
                if (expression == null) 
                    throw new ArgumentNullException("selector");
                LambdaExpression lambda = System.Linq.Dynamic.DynamicExpression.ParseLambda(q.ElementType, null, expression, values);
                Type[] types = new Type[] { q.ElementType, lambda.Body.Type };
                return q.Provider.CreateQuery(Expression.Call(typeof(Queryable), "Select", types, q.Expression, Expression.Quote(lambda)));
            }
            catch
            {
                return q;
            }
        }
