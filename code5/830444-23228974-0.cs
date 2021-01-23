            public static async Task<NamespaceDeclarationSyntax> GetNamespaceAsync(this Document document, CancellationToken cancellationToken = default(CancellationToken))
            {
                SyntaxNode documentRoot = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);
                var rootCompUnit = (CompilationUnitSyntax)documentRoot;
                return (NamespaceDeclarationSyntax)rootCompUnit.Members.Where(m => m.IsKind(SyntaxKind.NamespaceDeclaration)).Single();
            }
