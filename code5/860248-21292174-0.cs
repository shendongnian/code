    public static class ExtensionMethods
    {
        public static IQueryable<TEntity> TestPerKey<TEntity, TKey>( 
            this IQueryable<TEntity> query, 
            IEnumerable<TKey> keys, 
            Expression<Func<TEntity, TKey, bool>> testExpression )
        {
            // create expression parameter
            var arg = Expression.Parameter( typeof( TEntity ), "entity" );
            // expression body var
            Expression expBody = null;
            // for each key, invoke testExpression, logically OR results
            foreach( var key in keys )
            {
                // constant expression for key
                var keyExp = Expression.Constant( key );
                // testExpression.Invoke expression
                var invokeExp = Expression.Invoke( testExpression, arg, keyExp );
                if( null == expBody )
                {
                    // first expression
                    expBody = invokeExp;
                }
                else
                {
                    // logically OR previous expression with new expression
                    expBody = Expression.Or( expBody, invokeExp );
                }
            }
            // execute Where method w/ created filter expression
            return query.Where( ( Expression<Func<TEntity, bool>> )Expression.Lambda( expBody, arg ) );
        }
    }
