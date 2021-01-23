    Expression<Predicate<TObject>> 
         GenerateAssignExpression<TObject, TProperty>(
             Expression<Func<TObject, TProperty>> getExpression,
             ExpressionType op, 
             TProperty Value)
        {
            var getExpressionBody = getExpression.Body as MemberExpression;
            if (getExpressionBody == null)
            {
                throw new Exception("getExpressionBody is not MemberExpression: " +
                        getExpression.Body);
            }
            
            return Expression.Lambda<Predicate<TObject>>(
                Expression.MakeBinary(op, getExpression, Expression.Constant(Value)),
                Expression.Parameter(typeof(TObject)));
        }
