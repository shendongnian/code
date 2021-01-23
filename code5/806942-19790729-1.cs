    Expression<Predicate<TObject>> 
         GenerateAssignExpression<TObject, TProperty>(
             Expression<Func<TObject, TProperty>> expression,
             ExpressionType op, 
             TProperty Value)
        {   
            return Expression.Lambda<Predicate<TObject>>(
                Expression.MakeBinary(op, expression, Expression.Constant(Value)),
                getExpression.Parameters[0]);
        }
