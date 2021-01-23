    public async Task<IEnumerable<CodeAction>> GetFixesAsync(Document document, TextSpan span, IEnumerable<Diagnostic> diagnostics, CancellationToken cancellationToken)
        {
            var root = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);
            var diagnosticSpan = diagnostics.First().Location.SourceSpan;
            var declaration = root.FindToken(diagnosticSpan.Start).Parent.AncestorsAndSelf().OfType<LocalDeclarationStatementSyntax>().First();
            return new[] { CodeAction.Create("Use var", c => ChangeDeclarationToVar(document, declaration, c)) };
        }
    private async Task<Document> ChangeDeclarationToVar(Document document, LocalDeclarationStatementSyntax localDeclaration, CancellationToken cancellationToken)
        {
            var root = await document.GetSyntaxRootAsync(cancellationToken);
            var variableTypeName = localDeclaration.Declaration.Type;
            var varTypeName = SyntaxFactory.IdentifierName("var").WithAdditionalAnnotations(Formatter.Annotation);
            var newDeclaration = localDeclaration.ReplaceNode(variableTypeName, varTypeName);            
            var newRoot = root.ReplaceNode(localDeclaration, newDeclaration);
            return document.WithSyntaxRoot(newRoot);
        }
