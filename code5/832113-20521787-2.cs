    var code = @"
        using System;
        public class Test
        {
            public void TestMethod()
            {
                var now = DateTime.Now;
                now.
            }
        }";
    Console.WriteLine(code);
    
    var syntaxTree = SyntaxTree.ParseText(code);
    var compilation = Compilation.Create("foo")
        .AddReferences(MetadataReference.CreateAssemblyReference(typeof(DateTime).Assembly.FullName))
        .AddSyntaxTrees(syntaxTree);
    var semanticModel = compilation.GetSemanticModel(syntaxTree);
    
    var dotTextSpan = new TextSpan(code.IndexOf("now.") + 3, 1);
    var memberAccessNode = (MemberAccessExpressionSyntax)syntaxTree.GetRoot().DescendantNodes(dotTextSpan).Last();
    
    var lhsType = semanticModel.GetTypeInfo(memberAccessNode.Expression).Type;
                
    foreach (var symbol in lhsType.GetMembers())
    {
        // Keep only public instance fields, properties and methods
        if (symbol.Kind != SymbolKind.Field
            && symbol.Kind != SymbolKind.Property
            && symbol.Kind != SymbolKind.Method)
            continue;
    
        if (!symbol.CanBeReferencedByName
            || symbol.DeclaredAccessibility != Accessibility.Public
            || symbol.IsStatic)
            continue;
    
        Console.WriteLine(symbol.Name);
    }
