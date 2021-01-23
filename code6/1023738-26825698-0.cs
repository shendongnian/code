    public Expression<Func<object, object>> ConvertToObject<TParm, TReturn>(Expression<Func<TParm, TReturn>> input)
    {
        var parm = Expression.Parameter(typeof(object));
        var castParm = Expression.Convert(parm, typeof(TParm));
        var body = ReplaceExpression(input.Body, input.Parameters[0], castParm);
        body = Expression.Convert(body, typeof(object));
        return Expression.Lambda<Func<object, object>>(body, parm);
    }
    public Expression<Func<TParm, TReturn>> ConvertBack<TParm, TReturn>(Expression<Func<object, object>> input)
    {
        var parm = Expression.Parameter(typeof(TParm));
        var castParm = Expression.Convert(parm, typeof(object));
        var body = ReplaceExpression(input.Body, input.Parameters[0], castParm);
        body = Expression.Convert(body, typeof(TReturn));
        return Expression.Lambda<Func<TParm, TReturn>>(body, parm);
    }
    Expression ReplaceExpression(Expression body, Expression source, Expression dest)
    {
        var replacer = new ExpressionReplacer(source, dest);
        return replacer.Visit(body);
    }
    public class ExpressionReplacer : ExpressionVisitor
    {
        Expression _source;
        Expression _dest;
        public ExpressionReplacer(Expression source, Expression dest)
        {
            _source = source;
            _dest = dest;
        }
        public override Expression Visit(Expression node)
        {
            if (node == _source)
                return _dest;
            return base.Visit(node);
        }
    }
