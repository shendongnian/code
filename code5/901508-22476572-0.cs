    public Expression<Func<TEntity, bool>> SearchExpression()
    {
        ConstantExpression[] expectedValues = Your_Magic_Method_Of_Obtaining_Expected_Values();
        var entity = Expression.Parameter(typeof (TEntity));
        var comparisonExpression = typeof(TEntity).GetProperties()
                                                  .Select((info, i) => Expression.Equal(
                                                                          Expression.Property(entity, info),
                                                                          expectedValues[i]))
                                                  .Aggregate(Expression.And);
        return Expression.Lambda<Func<TEntity, bool>>(comparisonExpression, entity);
    }
