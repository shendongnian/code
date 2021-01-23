        public static IQueryable<TestEntity> TestPerKey(
            this IQueryable<TestEntity> query,
            IEnumerable<string> keys )
        {
            MethodInfo containsMethodInfo = typeof( string ).GetMethod( "Contains" );
            // create expression parameter
            var arg = Expression.Parameter( typeof( TestEntity ), "entity" );
            // expression body var
            Expression expBody = null;
            // for each key, invoke testExpression, logically OR results
            foreach( var key in keys )
            {
                var expression = Expression.OrElse(
                    Expression.OrElse(
                        Expression.Call( Expression.Property( arg, "FirstName" ), containsMethodInfo, Expression.Constant( key ) ),
                        Expression.Call( Expression.Property( arg, "LastName" ), containsMethodInfo, Expression.Constant( key ) ) )
                    , Expression.Call( Expression.Property( arg, "CompanyName" ), containsMethodInfo, Expression.Constant( key ) ) );
                if( null == expBody )
                {
                    // first expression
                    expBody = expression;
                }
                else
                {
                    // logically OR previous expression with new expression
                    expBody = Expression.OrElse( expBody, expression );
                }
            }
            // execute Where method w/ created filter expression
            return query.Where( ( Expression<Func<TestEntity, bool>> )Expression.Lambda( expBody, arg ) );
        }
