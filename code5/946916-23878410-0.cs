    var workspace = MSBuildWorkspace.Create();
    var solution = workspace.OpenSolutionAsync("c:\\path\\to\\solution.sln").Result;
    foreach (var document in solution.Projects.SelectMany(project => project.Documents))
    {
        var rootNode = document.GetSyntaxRootAsync().Result;
        var semanticModel = document.GetSemanticModelAsync().Result;
        var variableDeclarations = rootNode
                .DescendantNodes()
                .OfType<VariableDeclarationSyntax>();
        foreach (var variableDeclaration in variableDeclarations)
        {
            var symbolInfo = semanticModel.GetSymbolInfo(variableDeclaration.Type);
            var typeSymbol = symbolInfo.Symbol;
            // 'typeSymbol ' now contains the type symbol for the variable..
        }
    }
