     class ModelCollector : CSharpSyntaxWalker
        {
            public readonly Dictionary<string, List<string>> models = new Dictionary<string, List<string>>();
            public override void VisitPropertyDeclaration(PropertyDeclarationSyntax node)
            {
                var classnode = node.Parent as ClassDeclarationSyntax;
                if (!models.ContainsKey(classnode.Identifier.ValueText))
                    models.Add(classnode.Identifier.ValueText, new List<string>());
    
                models[classnode.Identifier.ValueText].Add(node.Identifier.ValueText);
            }
          
        } 
    
    
        class Program
        {
            static void Main(string[] args)
            {
    
                var code =
    @"              using System; 
                    using System.Collections.Generic; 
                    using System.Linq; 
                    using System.Text; 
    
                    namespace HelloWorld 
                    { 
                        public class MyAwesomeModel
                        {
                            public string MyProperty {get;set;}
                            public int MyProperty1 {get;set;}
                        }
    
                    }";
    
                var tree = CSharpSyntaxTree.ParseText(code);
    
                var root = (CompilationUnitSyntax)tree.GetRoot();
                var modelCollector = new ModelCollector();
                modelCollector.Visit(root);
                Console.WriteLine(JsonConvert.SerializeObject(modelCollector.models));
    
               
            }
        }
