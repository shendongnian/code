    string code = @"namespace Foo
    {
        /// <summary>This is an xml doc comment <see cref=""MyClass"" /></summary>
        class MyClass {}
    }";
    
    var tree = SyntaxFactory.ParseSyntaxTree(code);
    CrefSyntax cref = tree.GetRoot()
        .DescendantNodes(descendIntoTrivia: true)
        .OfType<CrefSyntax>()
        .FirstOrDefault();
    var compliation = CSharpCompilation.Create("foo").AddSyntaxTrees(tree);
    var model = compliation.GetSemanticModel(tree);
    ISymbol symbol = model.GetSymbolInfo(cref).Symbol;
