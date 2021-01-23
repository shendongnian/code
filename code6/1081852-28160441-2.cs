    string BuildFullTestName(MethodDeclarationSyntax method)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(method.Identifier.ValueText);
        SyntaxNode node = method;
        while(node.Parent is ClassDeclarationSyntax)
        {
            node = node.Parent;
            sb.Insert(0, ".");
            sb.Insert(0, ((ClassDeclarationSyntax)node).Identifier.ValueText);
        }
        if(node.Parent is NamespaceDeclarationSyntax)
        {
            node = node.Parent;
            sb.Insert(0, ".");
            sb.Insert(0, ((NamespaceDeclarationSyntax)node).Name.ToString());
        }
        else
        {
            throw new Exception("method \{method.Identifier.ValueText} has wierd parents.");
        }
        return sb.ToString();
    }
