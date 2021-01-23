    private sealed class EntityCastRemoverVisitor : ExpressionVisitor
    {
        public static Expression<Func<T, bool>> Convert<T>(
            Expression<Func<T, bool>> predicate)
        {
            var visitor = new EntityCastRemoverVisitor();
            var visitedExpression = visitor.Visit(predicate);
            return (Expression<Func<T, bool>>)visitedExpression;
        }
        protected override Expression VisitUnary(UnaryExpression node)
        {
            if (node.NodeType == ExpressionType.Convert && node.Type == typeof(IEntity))
            {
                return node.Operand;
            }
            return base.VisitUnary(node);
        }
    }
