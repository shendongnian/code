    public static IEnumerable<ExpressionSyntax> Split(ExpressionSyntax expression)
    {
        return new SplitVisitor().Visit(expression);
    }
    class SplitVisitor : CSharpSyntaxVisitor<IEnumerable<ExpressionSyntax>>
    {
        public override IEnumerable<ExpressionSyntax> VisitInvocationExpression(
            InvocationExpressionSyntax node)
        {
            yield return node.Expression;
            var argumentExpressions = node.ArgumentList.Arguments
                .SelectMany(a => Visit(a.Expression));
            foreach (var expression in argumentExpressions)
                yield return expression;
        }
        public override IEnumerable<ExpressionSyntax> VisitBinaryExpression(
            BinaryExpressionSyntax node)
        {
            foreach (var expression in Visit(node.Left))
                yield return expression;
            foreach (var expression in Visit(node.Right))
                yield return expression;
        }
        public override IEnumerable<ExpressionSyntax> DefaultVisit(SyntaxNode node)
        {
            var expression = node as ExpressionSyntax;
            if (expression != null)
                yield return expression;
        }
    }
