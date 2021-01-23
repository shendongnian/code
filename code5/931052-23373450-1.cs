        public Expression<Func<TEntity, TCacheItem>> BuildSelector<TEntity, TCacheItem>(TEntity entity)
        {
            List<MemberBinding> memberBindings = new List<MemberBinding>();
            MemberInitExpression body = null;
            foreach (var entityPropertyInfo in typeof(TEntity).GetProperties())
            {
                foreach (var cachePropertyInfo in typeof(TCacheItem).GetProperties())
                {
                    if (entityPropertyInfo.PropertyType == cachePropertyInfo.PropertyType && entityPropertyInfo.Name == cachePropertyInfo.Name)
                    {
                        var fieldExpressoin = Expression.Field(Expression.Constant(entity), entityPropertyInfo.Name);
                        memberBindings.Add(Expression.Bind(cachePropertyInfo, fieldExpressoin));
                    }
                }
            }
            
            var parameterExpression = Expression.Parameter(typeof(TEntity), "x");
            var newExpr = Expression.New(typeof(TCacheItem));
            body = Expression.MemberInit(newExpr, memberBindings);
            return Expression.Lambda<Func<TEntity, TCacheItem>>(body, parameterExpression);
        }
