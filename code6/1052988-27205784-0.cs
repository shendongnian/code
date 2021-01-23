    /// <summary>
    /// Returns all fields/properties from <paramref name="source"/> except for the field(s)/property(ies) listed in the selector expression.
    /// </summary>
    public static IQueryable SelectExcept<TSource, TResult>( this IQueryable<TSource> source, Expression<Func<TSource, TResult>> selector )
    {
        var newExpression = selector.Body as NewExpression;
        var excludeProperties = newExpression != null
                ? newExpression.Members.Select( m => m.Name )
                : new[] { ( (MemberExpression)selector.Body ).Member.Name };
        
        var sourceType = typeof( TSource );
        var allowedSelectTypes = new Type[] { typeof( string ), typeof( ValueType ) };
        var sourceProperties = sourceType.GetProperties( BindingFlags.Public | BindingFlags.Instance ).Where( p => allowedSelectTypes.Any( t => t.IsAssignableFrom( ( (PropertyInfo)p ).PropertyType ) ) ).Select( p => ( (MemberInfo)p ).Name );
        var sourceFields = sourceType.GetFields( BindingFlags.Public | BindingFlags.Instance ).Where( f => allowedSelectTypes.Any( t => t.IsAssignableFrom( ( (FieldInfo)f ).FieldType ) ) ).Select( f => ( (MemberInfo)f ).Name );
        var selectFields = sourceProperties.Concat( sourceFields ).Where( p => !excludeProperties.Contains( p ) ).ToArray();
        
        var dynamicSelect = 
                string.Format( "new( {0} )",
                        string.Join( ", ", selectFields ) );
        return selectFields.Count() > 0
            ? source.Select( dynamicSelect )
            : Enumerable.Empty<TSource>().AsQueryable<TSource>();
    }
