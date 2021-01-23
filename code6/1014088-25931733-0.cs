    var cSharpProvider = CodeDomProvider.CreateProvider("C#");
    var variableDecl = new CodeVariableDeclarationStatement(caller.GetType(), "_");
    var sb = new StringBuilder();
    using (var sw = new StringWriter(sb))
    {
       cSharpProvider.GenerateCodeFromStatement(variableDecl,
                                                sw,
                                                new CodeGeneratorOptions());
    }
    sb.Remove(sb.Length - 5, 5); //remove " _;\n";
