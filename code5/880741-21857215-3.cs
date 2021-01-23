    class RemoveConvertToObjectExpressionVisitor : ExpressionVisitor {
        private bool topLevel = true;
        protected override Expression VisitUnary(UnaryExpression node) {
            bool currentTop = topLevel;
            topLevel = false;
            if (currentTop && (node.NodeType == ExpressionType.Convert || node.NodeType == ExpressionType.ConvertChecked)) {
                return base.Visit(node.Operand);
            }
            return base.VisitUnary(node);
        }
        /// You need to override all VisitXyz methods with the same code
        protected override Visit...(...Expression node) {
            topLevel = false;
            return base.Visit(node);
        }
    }
