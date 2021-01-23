    public static Expression MakeUnchecked(this Expression expression)
    {
        return new UncheckedExpressionVisitor().Visit(expression);
    }
    public class UncheckedExpressionVisitor : ExpressionVisitor
    {
        protected override Expression VisitBinary(BinaryExpression node)
        {
            switch (node.NodeType)
            {
                case ExpressionType.AddAssignChecked:
                    return base.Visit(Expression.AddAssign(node.Left, node.Right));
                case ExpressionType.AddChecked:
                    return base.Visit(Expression.Add(node.Left, node.Right));
                case ExpressionType.MultiplyAssignChecked:
                    return base.Visit(Expression.MultiplyAssign(node.Left, node.Right));
                case ExpressionType.MultiplyChecked:
                    return base.Visit(Expression.Multiply(node.Left, node.Right));
                case ExpressionType.SubtractAssignChecked:
                    return base.Visit(Expression.SubtractAssign(node.Left, node.Right));
                case ExpressionType.SubtractChecked:
                    return base.Visit(Expression.Subtract(node.Left, node.Right));
                default:
                    return base.VisitBinary(node);
            }
        }
        protected override Expression VisitUnary(UnaryExpression node)
        {
            switch (node.NodeType)
            {
                case ExpressionType.ConvertChecked:
                    return base.Visit(Expression.Convert(node.Operand, node.Type));
                case ExpressionType.NegateChecked:
                    return base.Visit(Expression.Negate(node.Operand, node.Method));
                default:
                    return base.VisitUnary(node);
            }
        }
    }
