    // build theIQ.Where( pe2 => innerCondition )
    Type queryableType = typeof( Queryable );
    var delegateType = typeof( Func<PivotElement, bool> );
    MethodCallExpression innerWhere = Expression.Call( 
        queryableType, 
        "Where", 
        new Type[] { elementType }, 
        new Expression[] { 
            theIQ.Expression, 
            Expression.Lambda(
                delegateType, innerCondition, new ParameterExpression[] { pe2 } 
            )
        } 
    );
    // build theIQ.Where( pe2 => innerWhere ).Any()
    MethodCallExpression anyCall = Expression.Call( 
        queryableType, "Any", new Type[] { elementType }, innerWhere 
    );
    // build iQCopy.Where( pe1 => anyCall )
    MethodCallExpression outerWhere = Expression.Call( 
        queryableType, 
        "Where",
        new Type[] { elementType }, 
        new Expression[] { 
            iQCopy.Expression, 
            Expression.Lambda( 
                delegateType, anyCall, new ParameterExpression[] { pe1 } 
            )
        }
    );
            
    // create the final query
    var results = iQCopy.Provider.CreateQuery<PivotElement>( outerWhere );
