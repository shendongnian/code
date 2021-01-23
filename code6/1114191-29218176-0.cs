    public static Expression<Func<TFirstParam, TResult>>
        Compose<TFirstParam, TIntermediate, TResult>(
        this Expression<Func<TFirstParam, TIntermediate>> first,
        Expression<Func<TIntermediate, TResult>> second)
    {
        var param = Expression.Parameter(typeof(TFirstParam), "param");
        var newFirst = first.Body.Replace(first.Parameters[0], param);
        var newSecond = second.Body.Replace(second.Parameters[0], newFirst);
        return Expression.Lambda<Func<TFirstParam, TResult>>(newSecond, param);
    }
    internal class ReplaceVisitor : ExpressionVisitor
    {
        private readonly Expression from, to;
        public ReplaceVisitor(Expression from, Expression to)
        {
            this.from = from;
            this.to = to;
        }
        public override Expression Visit(Expression node)
        {
            return node == from ? to : base.Visit(node);
        }
    }
    public static Expression Replace(this Expression expression,
        Expression searchEx, Expression replaceEx)
    {
        return new ReplaceVisitor(searchEx, replaceEx).Visit(expression);
    }
