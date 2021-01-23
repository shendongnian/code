        private Expression<Func<TElement, bool>> GetConditionExpression(TKey key)
        {
            var param = Expression.Parameter(typeof(TElement));
            return
                Expression.Lambda<Func<TElement, bool>>(
                    Expression.Equal(
                        Expression.Invoke(
                            dbKey,
                            param
                        ),
                        Expression.Constant(key)
                    ),
                param
                );
        }
