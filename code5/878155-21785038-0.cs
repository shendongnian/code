    MethodDeclarationSyntax lMethodDeclarationSyntax =
        Syntax.MethodDeclaration(
            Syntax.List<AttributeListSyntax>(),
            Syntax.TokenList(Syntax.Token(SyntaxKind.PublicKeyword)),
            Syntax.IdentifierName("MemoryStream"),
            null,
            Syntax.Identifier("Serialize"),
            null,
            Syntax.ParameterList(),
            Syntax.List<TypeParameterConstraintClauseSyntax>(),
            Syntax.Block(lList))
        .NormalizeWhitespace();
