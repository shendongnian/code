    MethodDeclarationSyntax AddMethodProperty(MethodDeclarationSyntax method, string propertyName, string argumentName)
    {
        return method.AddAttributeLists(
                SyntaxFactory.AttributeList(
                    SyntaxFactory.SingletonSeparatedList(
                        SyntaxFactory.Attribute(
                            SyntaxFactory.IdentifierName(propertyName),
                            SyntaxFactory.AttributeArgumentList(
                                SyntaxFactory.SingletonSeparatedList(
                                    SyntaxFactory.AttributeArgument(
                                        SyntaxFactory.LiteralExpression(
                                            SyntaxKind.StringLiteralExpression,
                                            SyntaxFactory.Token(
                                                default(SyntaxTriviaList),
                                                SyntaxKind.StringLiteralToken,
                                                argumentName,
                                                argumentName,
                                                default(SyntaxTriviaList))
                                            ))))))));
    }
