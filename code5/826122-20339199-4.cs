    string GetPropertyGetter(string filename, string propertyName)
    {
        var syntaxTree = SyntaxTree.ParseFile(filename);
        var root = syntaxTree.GetRoot();
        var property = root.DescendantNodes()
                           .OfType<PropertyDeclarationSyntax>()
                           .Where(md => md.Identifier.ValueText.Equals(propertyName))
                           .FirstOrDefault();
        var getter = property.AccessorList.Accessors.First(a => a.Kind == SyntaxKind.GetAccessorDeclaration);
        return getter.ToString();
    }
