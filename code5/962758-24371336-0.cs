    public static void Seed<TSeed, TEntity>(this DbContext context, IEnumerable<TSeed> seeds, Expression<Func<TEntity, TSeed, bool>> predicate)
                where TEntity : class
                where TSeed : class
            {
                foreach (TSeed seed in seeds)
                {
                    Expression<Func<TEntity, bool>> matchExpression = (entity) => predicate.Invoke(entity, seed);
                    TEntity existing = context.Set<TEntity>().AsExpandable().FirstOrDefault(matchExpression);
                // Rest of code is omitted as it is not related to the original question.
                // The query above is properly executed by Linq 2 Entities.
                }
            }
