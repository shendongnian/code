    public static class ExpressionChainer
    {
        public static Expression<Func<TOuter, TInner>> Chain<TOuter, TMiddle, TInner>(
            this Expression<Func<TOuter, TMiddle>> left, Expression<Func<TMiddle, TInner>> right)
        {
            return ChainTwo(left, right);
        }
        public static Expression<Func<TOuter, TInner>> ChainTwo<TOuter, TMiddle, TInner>(
            Expression<Func<TOuter, TMiddle>> left, Expression<Func<TMiddle, TInner>> right)
        {
            var swap = new SwapVisitor(right.Parameters[0], left.Body);
            return Expression.Lambda<Func<TOuter, TInner>>(
                   swap.Visit(right.Body), left.Parameters);
        }
        private class SwapVisitor : ExpressionVisitor
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
    }
