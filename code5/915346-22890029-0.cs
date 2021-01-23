    Expression<Func<TSource, bool>> CombinePredicates<TSource>(
        Expression<Func<TSource, bool>> head,
        params Expression<Func<TSource, bool>>[] tail)
    {
        var param = head.Parameters.Single();
        var body = tail.Aggregate(
            head.Body,
            (result, expr) => Expression.AndAlso(result,
                new SubstitutionVisitor
                {
                    OldExpr = expr.Parameters.Single(),
                    NewExpr = param,
                }.Visit(expr.Body)
            )
        );
        return Expression.Lambda<Func<TSource, bool>>(body, param);
    }
    
    public class SubstitutionVisitor : ExpressionVisitor
    {
        public Expression OldExpr { get; set; }
        public Expression NewExpr { get; set; }
    
        public override Expression Visit(Expression node)
        {
            return (node == OldExpr) ? NewExpr : base.Visit(node);
        }
    }
