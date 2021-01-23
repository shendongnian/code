    namespace GettingStartedCS
    {
        class Program
        {
            static void Main(string[] args)
            {
                SyntaxTree tree = SyntaxTree.ParseCompilationUnit(
    @"using System;
    using System.Collections;
    using System.Linq;
    using System.Text;
    namespace HelloWorld
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine(""Hello, World!"");
            }
        }
    }");
     
                var root = (CompilationUnitSyntax)tree.GetRoot();
     
                var firstMember = root.Members[0];
     
                var helloWorldDeclaration = (NamespaceDeclarationSyntax)firstMember;
     
                var programDeclaration = (TypeDeclarationSyntax)helloWorldDeclaration.Members[0];
     
                var mainDeclaration = (MethodDeclarationSyntax)programDeclaration.Members[0];
     
                var argsParameter = mainDeclaration.ParameterList.Parameters[0];
     
            }
        }
    }
