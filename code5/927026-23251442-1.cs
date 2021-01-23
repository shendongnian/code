        private async Task<List<MethodDeclarationSyntax>> GetMethodSymbolReferences( IMethodSymbol methodSymbol )
        {
            var references = new List<MethodDeclarationSyntax>();
            var referencingSymbols = await SymbolFinder.FindReferencesAsync(methodSymbol, _solution);
            var referencingSymbolsList = referencingSymbols as IList<ReferencedSymbol> ?? referencingSymbols.ToList();
            if (!referencingSymbolsList.Any(s => s.Locations.Any()))
            {
                return references;
            }
            foreach (var referenceSymbol in referencingSymbolsList)
            {
                foreach (var referenceLocation in referenceSymbol.Locations)
                {
                    var position = referenceLocation.Location.SourceSpan.Start;
                    var root = await referenceLocation.Location.SourceTree.GetRootAsync();
                    var nodes = root.FindToken(position).Parent.AncestorsAndSelf().OfType<MethodDeclarationSyntax>();
                    references.AddRange(nodes);
                }
            }
            return references;
        }
