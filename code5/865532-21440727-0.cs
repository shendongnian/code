    public Expression<Func<TEntity, bool>> EmployeeFilterDelegateExp<TEntity>( 
        int costCenterId, 
        int rankId )
    {
        var parm = Expression.Parameter( typeof( TEntity ), "entity" );
        var employeeProperty = Expression.Property( parm, "Employee" );
        return ( Expression<Func<TEntity, bool>> )Expression.Lambda(
            Expression.AndAlso(
                Expression.Equal( Expression.Property( employeeProperty, "CostCenterID" ), 
                    Expression.Constant( costCenterId ) ),
                Expression.Equal( Expression.Property( employeeProperty, "Rank" ), 
                    Expression.Constant( rankId ) ) ),
            parm );
    }
