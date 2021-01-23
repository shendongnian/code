    static void GetClassMethod(string filename, string className, string methodName)
    {
        var syntaxTree = SyntaxTree.ParseFile(filename);
        var root = syntaxTree.GetRoot();
        var @class = root.DescendantNodes()
                          .OfType<ClassDeclarationSyntax>()
                          .Where(md => md.Identifier.ValueText.Equals(className))
                          .FirstOrDefault();
        var method = @class.DescendantNodes()
                          .OfType<MethodDeclarationSyntax>()
                          .Where(md => md.Identifier.ValueText.Equals(methodName))
                          .FirstOrDefault();
    }
