    var parser = new CSharpParser();
    var syntaxTree = parser.Parse(code);
   
    var classes = syntaxTree.Descendants.OfType<TypeDeclaration>().Where(x => x.ClassType == ClassType.Class);
    foreach (var typeDeclaration in classes)
    {
        var result = typeDeclaration.Descendants.Where(d => d is MethodDeclaration || d is PropertyDeclaration);
        foreach (var declaration in result )
        {
            //...
        }
    }
