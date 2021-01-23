    static class FunctionalExtensions
    {
        public static Expression<Func<A, C>> Compose<A, B, C>(this Expression<Func<A, B>> f, Expression<Func<B, C>> g)
        {
            var ex = SubstituteIn(g.Body, g.Parameters[0], f.Body);
            return Expression.Lambda<Func<A, C>>(ex, f.Parameters[0]);
        }
        static TExpr SubstituteIn<TExpr>(TExpr expression, Expression orig, Expression replacement) where TExpr : Expression
        {
            var replacer = new SwapVisitor(orig, replacement);
            return replacer.VisitAndConvert(expression, "ReplaceExpressions");
        }
    }
    class SwapVisitor : ExpressionVisitor
    {
        private readonly Expression from, to;
        public SwapVisitor(Expression from, Expression to)
        {
            this.from = from;
            this.to = to;
        }
        public override Expression Visit(Expression node)
        {
            return node == from ? to : base.Visit(node);
        }
    }
