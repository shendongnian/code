    var tree = SyntaxTree.ParseText(@"namespace Foo
    {
        public class Bar
        {
            public string Biz()
            {
                return ""Baz"";
            }
        }
    }");
    var annotatedTree = SyntaxTree.Create(tree.GetRoot()
        .WithLeadingTrivia(
            Syntax.Comment(String.Format("// source: scratch")),
            Syntax.Comment(String.Format("// date: {0}", DateTime.Now))
        )
        .NormalizeWhitespace()
    );
