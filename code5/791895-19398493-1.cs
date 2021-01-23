    var methodRef = (InvocationExpressionSyntax)find_method();
    var genericArguments = methodRef.DescendantNodes().OfType<GenericNameSyntax>().FirstOrDefault();
    
    if (genericArguments != null)
       foreach (var g_arg in genericArguments.TypeArgumentList.Arguments)
          Console.WriteLine(g_arg);
    static InvocationExpressionSyntax find_method()
    {
       var code = new StreamReader("..\\..\\Tests.cs").ReadToEnd();
       SyntaxTree tree = SyntaxTree.ParseText(code);
       var root = tree.GetRoot();
       //find your methods here
       return (InvocationExpressionSyntax)root.DescendantNodes().ToArray()[88];
    }
