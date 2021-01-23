    public class BinaryExpressionVisitor : CSharpSyntaxRewriter
    {
        List<string> restrictedTokens = new List<string>();
        internal List<object> binaryExpressionNodes = new List<object>();
        public BinaryExpressionVisitor()
        {
            restrictedTokens.Add("IdentifierToken");
            restrictedTokens.Add("NumericLiteralToken");
            restrictedTokens.Add("StringLiteralToken");
        }
        public override SyntaxNode VisitBinaryExpression(BinaryExpressionSyntax node)
        {
            return base.VisitBinaryExpression(node);
        }
        public override SyntaxNode Visit(SyntaxNode node)
        {
            if (node.GetType().Name != "BinaryExpressionSyntax" && node.GetType().Name != "ParenthesizedExpressionSyntax")
                binaryExpressionNodes.Add(node);
            return base.Visit(node);
        }
        public override SyntaxToken VisitToken(SyntaxToken token)
        {
            if (!restrictedTokens.Contains(token.CSharpKind().ToString().Trim()))
                binaryExpressionNodes.Add(token);
            SyntaxToken baseToken = base.VisitToken(token);
            return baseToken;
        }
        public override SyntaxNode VisitInvocationExpression(InvocationExpressionSyntax node)
        {
            return node;//Bypassing the expression instead of base.Visit(node)
        }
        public override SyntaxToken VisitListSeparator(SyntaxToken separator)
        {
            SyntaxToken baseToken = base.VisitListSeparator(separator);
            return baseToken;
        }
    }
