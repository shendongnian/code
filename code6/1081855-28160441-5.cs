    MethodDeclarationSyntax GetMethodFromSyntaxRoot(CompilationUnitSyntax root, string nameSpaceName, string className, MethodDeclarationSyntax method)
    {
        var result = root.Members.OfType<NamespaceDeclarationSyntax>().Single(ns => ns.Name.ToString() == nameSpaceName)
           .DescendantNodes(d => true).OfType<ClassDeclarationSyntax>().Single(c => c.Identifier.ValueText == className)
               .Members.OfType<MethodDeclarationSyntax>().SingleOrDefault(m => m.Identifier.ValueText == method.Identifier.ValueText && m.ParameterList.ToString() == method.ParameterList.ToString());
    }
