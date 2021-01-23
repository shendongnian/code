    public static SyntaxKind GetPrefixUnaryExpression(SyntaxKind token)
    {
        switch (token)
        {
            case SyntaxKind.PlusToken:
                return SyntaxKind.UnaryPlusExpression;
            case SyntaxKind.MinusToken:
                return SyntaxKind.UnaryMinusExpression;
            case SyntaxKind.TildeToken:
                return SyntaxKind.BitwiseNotExpression;
            case SyntaxKind.ExclamationToken:
                return SyntaxKind.LogicalNotExpression;
            case SyntaxKind.PlusPlusToken:
                return SyntaxKind.PreIncrementExpression;
            case SyntaxKind.MinusMinusToken:
                return SyntaxKind.PreDecrementExpression;
            case SyntaxKind.AmpersandToken:
                return SyntaxKind.AddressOfExpression;
            case SyntaxKind.AsteriskToken:
                return SyntaxKind.PointerIndirectionExpression;
            default:
                return SyntaxKind.None;
        }
    }
