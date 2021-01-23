    private BoundExpression BindAddressOfExpression(PrefixUnaryExpressionSyntax node, DiagnosticBag diagnostics)
    {
        if (!this.InUnsafeRegion)
        {
            return BindInvocationExpression(
                (InvocationExpressionSyntax)SyntaxFactory.ParseExpression(string.Format(
                    "System.Property.Bind(v => {0} = v, () => {0})",
                    node.Operand.GetText())), diagnostics);
        }
