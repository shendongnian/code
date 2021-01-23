    internal class EqualsReplacer : ExpressionVisitor
    {
        // public static bool Enumerable.SequenceEqual<byte>(this IEnumerable<byte> first, IEnumerable<byte> second)
        private static readonly MethodInfo SequenceEqualMethod = typeof(Enumerable)
            .GetMethods(BindingFlags.Static | BindingFlags.Public)
            .Where(x => x.Name == "SequenceEqual")
            .First(x => x.GetParameters().Length == 2)
            .MakeGenericMethod(typeof(byte));
        protected override Expression VisitBinary(BinaryExpression node)
        {
            // Skip all nodes except 'Equal' nodes
            if (node.NodeType != ExpressionType.Equal)
                return base.VisitBinary(node);
            // Skip all 'Equal' nodes with arguments other than byte[]
            if (node.Left.Type != typeof(byte[]) || node.Right.Type != typeof(byte[]))
                return base.VisitBinary(node);
            // Apply rewrite for all inner nodes
            var left = Visit(node.Left);
            var right = Visit(node.Right);
            // Rewrite expression, changing Equals
            return Expression.Call(SequenceEqualMethod, left, right);
        }
    }
