    public static class Helper {
        public static IEnumerable<T> Select<T>( this IEnumerable enumerable, string memberName ) {
            IQueryable queryable = enumerable.AsQueryable();
            LambdaExpression expression = PredicateFor( queryable.ElementType, memberName );
            return CreateQuery( queryable, "Select", new[] { expression.ReturnType }, expression ).Cast<T>();
        }
        public static MemberExpression NestedPropertyOrField(this Expression expression, string nestedPropertyOrFieldName) {
            MemberExpression e;
            if (nestedPropertyOrFieldName.IndexOf('.') >= 0) {
                var split = nestedPropertyOrFieldName.Split(new[] { '.' }, 2, StringSplitOptions.RemoveEmptyEntries);
                if (split.Length > 0) {
                    e = Expression.PropertyOrField(expression, split[0]);
                    if (split.Length > 1) {
                        e = NestedPropertyOrField(e, split[1]);
                    }
                } else {
                    throw new ArgumentException("'" + nestedPropertyOrFieldName + "' is not a member of type '" + expression.Type.AssemblyQualifiedName + "'");
                }
            } else {
                e = Expression.PropertyOrField(expression, nestedPropertyOrFieldName);
            }
            return e;
        }
        private static IEnumerable CreateQuery( IEnumerable enumerable, string method, Type[] typeArguments, params Expression[] arguments ) {
            IQueryable queryable = enumerable.AsQueryable();
            Type[] typeArgs = new[] { queryable.ElementType }.Concat( typeArguments ?? new Type[ 0 ] ).ToArray();
            Expression[] args = new[] { queryable.Expression }.Concat( arguments ?? new Expression[ 0 ] ).ToArray();
            MethodCallExpression methodCallExpression = Expression.Call( typeof( Queryable ), method, typeArgs, args );
            return queryable.Provider.CreateQuery( methodCallExpression );
        }
        internal static LambdaExpression PredicateFor( Type elementType, string memberName ) {
            var pe = Expression.Parameter( elementType, "@item" );
            Expression expression = pe;
            if ( memberName.StartsWith( "@item", StringComparison.OrdinalIgnoreCase ) ) {
                memberName = memberName.Substring( 5 );
            }
            if ( memberName.Length > 0 )
                expression = NestedPropertyOrField( expression, memberName );
            var delegateType = Expression.GetFuncType( elementType, expression.Type );
            return Expression.Lambda( delegateType, expression, new[] {pe} );
        }
    }
