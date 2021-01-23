    private static string GetQualifiedTypeName(ISymbol symbol)
    {
        var namespaceName = "";
        var ns = symbol.ContainingNamespace;
        while (ns != null && !ns.IsGlobalNamespace)
        {
            namespaceName = ns.Name + "." + namespaceName;
            ns = ns.ContainingNamespace;
        }
        return namespaceName + symbol.Name + ", " + symbol.ContainingAssembly;
    }
