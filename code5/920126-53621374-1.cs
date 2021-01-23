        public static bool IsEmptyPartialMethod(this IMethodSymbol method)
        {
            if (method.IsDefinedInMetadata())
                return false;
            foreach (var reference in method.DeclaringSyntaxReferences)
            {
                var syntax = reference.GetSyntax();
                if (syntax.Kind() != SyntaxKind.MethodDeclaration)
                    continue;
                var node = syntax as MethodDeclarationSyntax;
                if (node.Body != null || !node.Modifiers.Any(SyntaxKind.PartialKeyword))
                    return false;
            }
            return true;
        }
        public static bool IsDefinedInMetadata(this ISymbol symbol)
        {
            return symbol.Locations.Any(loc => loc.IsInMetadata);
        }
