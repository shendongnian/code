        public static bool IsPartialMethod(this IMethodSymbol method, out bool hasEmptyBody)
        {
            if (method.IsDefinedInMetadata())
            {
                hasEmptyBody = false;
                return false;
            }
            foreach (var reference in method.DeclaringSyntaxReferences)
            {
                var syntax = reference.GetSyntax();
                if (syntax.Kind() != SyntaxKind.MethodDeclaration)
                    continue;
                var node = syntax as MethodDeclarationSyntax;
                if (!node.Modifiers.Any(SyntaxKind.PartialKeyword))
                {
                    hasEmptyBody = false;
                    return false;
                }
            }
            hasEmptyBody = method.PartialImplementationPart == null || method.PartialDefinitionPart != null;
            return true;
        }
        /// <returns>False if it's not defined in source</returns>
        public static bool IsDefinedInMetadata(this ISymbol symbol)
        {
            return symbol.Locations.Any(loc => loc.IsInMetadata);
        }
