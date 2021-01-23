    public static IQueryable<QuestionsMetaDatas> FilterText(this IQueryable<QuestionsMetaDatas> queryable, IEnumerable<string> keywords)
            {
                var entityType = typeof(QuestionsMetaDatas);
                var parameter = Expression.Parameter(entityType, "a");
                var containsMethod = typeof(string).GetMethod("Contains"
                                                               , new[] { typeof(string) });
                var propertyExpression = Expression.Property(parameter, "Text");
                Expression body = Expression.Constant(false);
                foreach (var keyword in keywords)
                {
                    var innerExpression = Expression.Call(propertyExpression, containsMethod, Expression.Constant(keyword));
                    body = Expression.OrElse(body, innerExpression);
                }
                var lambda = Expression.Lambda<Func<QuestionsMetaDatas, bool>>(body, new[] { parameter });
                return queryable.Where(lambda);
    
            }
