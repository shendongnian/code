    public static string GetFullMetadataName(this INamespaceOrTypeSymbol symbol) 
    {
        ISymbol s = symbol;
        var sb = new StringBuilder(s.MetadataName);
        var orig = s;
        while (!IsRootNamespace(s)) 
        {
            s = s.ContainingSymbol;
            if (s is ITypeSymbol && orig is ITypeSymbol) 
            {
                sb.Insert(0, '+');
            } 
            else 
            {
                sb.Insert(0, '.');
            }
            sb.Insert(0, s.MetadataName);
        }
        return sb.ToString();
    }
    private static bool IsRootNamespace(ISymbol symbol) 
    {
        INamespaceSymbol s = null;
        return ((s = symbol as INamespaceSymbol) != null) && s.IsGlobalNamespace;
    }
