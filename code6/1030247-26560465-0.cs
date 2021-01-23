    var name = Syntax.QualifiedName(Syntax.IdentifierName("System"), Syntax.IdentifierName("Collections"));
    name = Syntax.QualifiedName(name, Syntax.IdentifierName("Generic"));
            
    SyntaxTree tree = SyntaxTree.ParseText(
    @"using System;
    using System.Collections;
    using System.Linq;
    using System.Text;
     
    namespace HelloWorld
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine(""Hello, World!"");
            }
        }
    }");
    var root = (CompilationUnitSyntax)tree.GetRoot();
    var oldUsing = root.Usings[1];
    var newUsing = oldUsing.WithName(name);
    root = root.ReplaceNode(oldUsing, newUsing);
    Console.WriteLine(root.GetText());
