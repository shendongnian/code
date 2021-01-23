     public static IQueryable<T> FieldsContains<T>(this IQueryable<T> query, List<string> fileds, string searchValue)
        {
            Expression predicate = null;
            var parameterExpression = Expression.Parameter(typeof(T), "type");
            foreach (string field in fileds)
            {
                var next = GetFieldContainsExpression<T>(parameterExpression, field, searchValue);
                if (predicate == null)
                {
                    predicate = next;
                }
                else
                {
                    predicate = Expression.Or(predicate, next);
                }
            }
            var lambda = Expression.Lambda<Func<T, bool>>(predicate, parameterExpression);
            return query.Where(lambda);
        }
        private static Expression GetFieldContainsExpression<T>(ParameterExpression parameterExpression, string field, string value)
        {
            var propertyType = typeof(T).GetProperty(field).PropertyType;
            Expression propertyExpression = Expression.Property(parameterExpression, field);
            var filterValue = Expression.Constant(value);
            var method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            //call toString first to ignore type errors(datetime, int ...)
            var toStringExpression = Expression.Call(propertyExpression, "ToString", Type.EmptyTypes);
            var containsExpression = Expression.Call(toStringExpression, method, filterValue);
            return containsExpression;
        }
