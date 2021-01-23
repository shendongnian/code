    class RemoveConvertToObjectExpressionVisitor : ExpressionVisitor {
        private bool topLevel = true;
        private bool processUnary = false;
        protected override Expression VisitLambda<T>(Expression<T> node) {
            if (!topLevel) {
                return base.VisitLambda(node);
            }
            topLevel = false;
            // Check the expression immediately under this lambda, and set the flag for the VisitUnary
            processUnary = node.Body.NodeType == ExpressionType.Convert
                        || node.Body.NodeType == ExpressionType.ConvertChecked;
            return base.VisitLambda(node);
        }
        // Here is your VisitUnary method with a small modification:
        protected override Expression VisitUnary(UnaryExpression node) {
            // processUnary is a one-time deal: only top level can set it to "true", in which case it is
            // immediately consumed by the call to VisitUnary which follows right away.
            if (!processUnary) {
                return base.VisitUnary(node);
            }
            // Only the top-level unary node needs to be processed
            processUnary = false;
            if (node.NodeType == ExpressionType.Convert || node.NodeType == ExpressionType.ConvertChecked) {
                return base.Visit(node.Operand);
            }
            return base.VisitUnary(node);
        }
    }
