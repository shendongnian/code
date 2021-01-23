    var root = await syntaxTree.GetRootAsync();
    var nodes = root.DescendantNodes(n => true);
    var st = root.SyntaxTree;
    var sm = this.compilation.GetSemanticModel(st);
    if (nodes != null)
    {
        var syntaxNodes = nodes as SyntaxNode[] ?? nodes.ToArray();
        // IdentifierNameSyntax:
        //  - var keyword
        //  - identifiers of any kind (including type names)
        var namedTypes = syntaxNodes
            .OfType<IdentifierNameSyntax>()
            .Select(id => sm.GetSymbolInfo(id).Symbol)
            .OfType<INamedTypeSymbol>()
            .ToArray();
        this.Add(namedTypes);
        // ExpressionSyntax:
        //  - method calls
        //  - property uses
        //  - field uses
        //  - all kinds of composite expressions
        var expressionTypes = syntaxNodes
            .OfType<ExpressionSyntax>()
            .Select(ma => sm.GetTypeInfo(ma).Type)
            .OfType<INamedTypeSymbol>()
            .ToArray();
        this.Add(expressionTypes);
    }
