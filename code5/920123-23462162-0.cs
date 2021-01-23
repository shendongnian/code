    foreach (var project in solution.Projects)
    {
        foreach (var document in project.Documents)
        {
            var methods = document
                .GetSyntaxRootAsync().Result
                .DescendantNodes()
                .OfType<MethodDeclarationSyntax>()
                .ToList();
            var semanticModel = document.GetSemanticModelAsync().Result;
            foreach (var method in methods)
            {
                if (method.Modifiers.All(m => m.ValueText != "partial"))
                    continue;
                var methodSymbol = semanticModel.GetDeclaredSymbol(method);
                if (methodSymbol.PartialDefinitionPart == null 
                    && methodSymbol.PartialImplementationPart == null)
                {
                    // found partial method without an implementation!
                }
            }
        }
    }
