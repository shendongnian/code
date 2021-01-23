    Expression<Func<TObject, TProperty>> GenerateAssignExpression<TObject, TProperty>
        (Expression<Func<TObject, TProperty>> getExpression,
        TProperty Value)
    {
        var getExpressionBody = getExpression.Body as MemberExpression;
        if (getExpressionBody == null)
        {
            throw new Exception("getExpressionBody is not MemberExpression: " + 
                    getExpression.Body);
        }
    
        var objectParameter = (ParameterExpression)getExpression.Parameters[0];
        ConstantExpression constant = Expression.Constant(Value, typeof(TProperty));
        var expAssign = Expression.Assign(e.Body, constant);
        return Expression.Lambda<Func<TObject, TProperty>>(expAssign, 
                objectParameter, 
                valueParameter);
    }
