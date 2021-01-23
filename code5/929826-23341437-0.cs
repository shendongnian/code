    string sourceCode = "class A { " +
                    "int field; " +
                    "void B(string parameter) { " +
                    "int a, b; int c; " +
                    "Action<string> q = (x) => { Console.WriteLine(x); }; " +
                    "}";
    //or parsefile etc
    var syntaxTree = CSharpSyntaxTree.ParseText(sourceCode);
    
    string[] identifierNames = syntaxTree.GetRoot().DescendantNodes()
                .OfType<VariableDeclaratorSyntax>().Select(v => v.Identifier.Text)
                .Concat(syntaxTree.GetRoot().DescendantNodes().OfType<ParameterSyntax>().Select(p => p.Identifier.Text))
                .ToArray();
    //identifierNames contains "field", "a", "b", "c", "q", "parameter", "x"
