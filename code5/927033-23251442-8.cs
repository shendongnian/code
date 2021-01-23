    private async Task<List<MethodDeclarationSyntax>> GetMethodSymbolReferences( IMethodSymbol methodSymbol )
    {
        var references = new List<MethodDeclarationSyntax>();
        var referencingSymbols = await SymbolFinder.FindCallersAsync(methodSymbol, _solution);
        var referencingSymbolsList = referencingSymbols as IList<SymbolCallerInfo> ?? referencingSymbols.ToList();
        if (!referencingSymbolsList.Any(s => s.Locations.Any()))
        {
            return references;
        }
        foreach (var referenceSymbol in referencingSymbolsList)
        {
            foreach (var location in referenceSymbol.Locations)
            {
                var position = location.SourceSpan.Start;
                var root = await location.SourceTree.GetRootAsync();
                var nodes = root.FindToken(position).Parent.AncestorsAndSelf().OfType<MethodDeclarationSyntax>();
                references.AddRange(nodes);
            }
        }
        return references;
    }
