    NamespaceDeclarationSyntax namespaceDeclarationSyntax = null;
    if (!SyntaxNodeHelper.TryGetParentSyntax(classDeclarationSyntax, out namespaceDeclarationSyntax))
    {
        return; // or whatever you want to do in this scenario
    }
    
    var namespaceName = namespaceDeclarationSyntax.Name.ToString();
    var fullClassName = namespace.Name + "." + classDeclarationSyntax.Identifier.ToString();
