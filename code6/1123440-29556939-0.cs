                public IQueryable<TEntity> Compare<TEntity>(IQueryable<TEntity> source, Expression<Func<TEntity, Nullable<short>>> func)
                {
                    return _Compare(source, func);
                }
    
                public IQueryable<TEntity> Compare<TEntity>(IQueryable<TEntity> source, Expression<Func<TEntity, Nullable<int>>> func)
                {
                    return _Compare(source, func);
                }
    
                public IQueryable<TEntity> Compare<TEntity>(IQueryable<TEntity> source, Expression<Func<TEntity, Nullable<DateTime>>> func)
                {
                    return _Compare(source, func);
                }
    
                public IQueryable<TEntity> Compare<TEntity>(IQueryable<TEntity> source, Expression<Func<TEntity, string>> func)
                {
                    return _Compare(source, func);
                }
    
                private IQueryable<TEntity> _Compare<TEntity>(IQueryable<TEntity> source, object func)
                {
                    IQueryable<TEntity> res = source;
    
                    Type type = func.GetType();
                    Expression funcBody = (Expression)type.GetProperty("Body").GetValue(func);
                    IEnumerable<ParameterExpression> funcParameters = (IEnumerable<ParameterExpression>)type.GetProperty("Parameters").GetValue(func);
    
                    if (!this.LBoundIsNull)
                    {
                        Expression ge = _Comparison(funcBody, Expression.Constant(_lBound), ExpressionType.GreaterThanOrEqual);
                        var lambda = Expression.Lambda<Func<TEntity, bool>>(ge, funcParameters);
                        res = res.Where(lambda);
                    }
    
                    if (!this.UBoundIsNull)
                    {
                        Expression le = _Comparison(funcBody, Expression.Constant(_uBound), ExpressionType.LessThanOrEqual);
                        var lambda = Expression.Lambda<Func<TEntity, bool>>(le, funcParameters);
                        res = res.Where(lambda);
                    }
    
                    return res;
                }
    
                private Expression _Comparison(Expression left, Expression right, ExpressionType expressionType)
                {
                    if (left.Type.IsNullable() && !right.Type.IsNullable())
                        right = Expression.Convert(right, left.Type);
                    else if (!left.Type.IsNullable() && right.Type.IsNullable())
                        left = Expression.Convert(left, right.Type);
    
                    if (left.Type == typeof(string))
                    {
                        var method = left.Type.GetMethod("CompareTo", new[] { typeof(string) });
                        var result = Expression.Call(left, method, right);
                        return Expression.MakeBinary(expressionType, result, Expression.Constant(0));
                    }
                    else
                        switch (expressionType)
                        {
                            case ExpressionType.GreaterThanOrEqual:
                                return Expression.GreaterThanOrEqual(left, right);
                            case ExpressionType.LessThanOrEqual:
                                return Expression.LessThanOrEqual(left, right);
                            default:
                                return Expression.Equal(left, right);
                        }
                }
