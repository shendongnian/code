    public async Task<IEnumerable<CodeAction>> GetFixesAsync(Document document, TextSpan span, IEnumerable<Diagnostic> diagnostics, CancellationToken cancellationToken)
    {
        return new[] { CodeAction.Create("Add 'Public' Keyword", CreateAction(document, span, cancellationToken, SyntaxKind.PublicKeyword)),
                       CodeAction.Create("Add 'Internal' Keyword", CreateAction(document, span, cancellationToken, SyntaxKind.InternalKeyword)),
                       CodeAction.Create("Add 'Protected' Keyword", CreateAction(document, span, cancellationToken, SyntaxKind.ProtectedKeyword)),
                       CodeAction.Create("Add 'Private' Keyword", CreateAction(document, span, cancellationToken, SyntaxKind.PrivateKeyword)),
        };
    }
    public Func<CancellationToken, Task<Document>> CreateAction(Document document, TextSpan span, CancellationToken cancellationToken, SyntaxKind accessModifierToken)
    {
        return new Func<CancellationToken, Task<Document>>(async x =>
        {
            var root = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);
            var token = root.FindToken(span.Start);
            var methodDeclaration = token.Parent as MethodDeclarationSyntax;
            var publicTokenList = new SyntaxTokenList() { };
            var newModifiers  = SyntaxFactory.TokenList(SyntaxFactory.Token(accessModifierToken)).AddRange(methodDeclaration.Modifiers);
            var newMethodDeclaration = methodDeclaration.WithModifiers(newModifiers).WithAdditionalAnnotations(Formatter.Annotation);
            var newRoot = root.ReplaceNode(methodDeclaration, newMethodDeclaration);
            var newDocument = document.WithSyntaxRoot(newRoot);
            return newDocument;
        });
    }
