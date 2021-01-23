    static void Main()
    {
        Console.WriteLine(((Expression<Func<short, short, bool>>)((s, s1) => s == s1)).Unmunge());
        Console.WriteLine(((Expression<Func<byte, byte, bool>>)((s, s1) => s == s1)).Unmunge());  
    }
    static Expression<T> Unmunge<T>(this Expression<T> expression)
    {
        return (Expression<T>)RedundantConversionVisitor.Default.Visit(expression);
    }
    class RedundantConversionVisitor : ExpressionVisitor
    {
        private RedundantConversionVisitor() { }
        public static readonly RedundantConversionVisitor Default = new RedundantConversionVisitor();
        protected override Expression VisitBinary(BinaryExpression node)
        {
            if(node.Type == typeof(bool) && node.Method == null
                && node.Left.NodeType == ExpressionType.Convert && node.Right.NodeType == ExpressionType.Convert
                && node.Left.Type == node.Right.Type)
            {
                UnaryExpression lhs = (UnaryExpression)node.Left, rhs = (UnaryExpression)node.Right;
                if (lhs.Method == null && rhs.Method == null && lhs.Operand.Type == rhs.Operand.Type)
                {
                    // work directly on the inner values
                    return Expression.MakeBinary(node.NodeType, lhs.Operand, rhs.Operand, node.IsLiftedToNull, node.Method);
                }
            }
            return base.VisitBinary(node);
        }
    }
