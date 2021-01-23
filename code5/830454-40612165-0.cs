    public static string GetFullName(NamespaceDeclarationSyntax node)
    {
        if (node.Parent is NamespaceDeclarationSyntax)
            return String.Format("{0}.{1}",
                GetFullName((NamespaceDeclarationSyntax)node.Parent),
                ((IdentifierNameSyntax)node.Name).Identifier.ToString());
        else
            return ((IdentifierNameSyntax)node.Name).Identifier.ToString();
    }
