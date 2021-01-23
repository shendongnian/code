        using System;
        using Microsoft.CodeAnalysis;
        using Microsoft.CodeAnalysis.CSharp;
        
        public class SyntaxTreeWriter : CSharpSyntaxWalker
        {
            public static void Write(string code)
            {
                var options = new CSharpParseOptions(kind: SourceCodeKind.Script);
                var syntaxTree = CSharpSyntaxTree.ParseText(code, options);
                new SyntaxTreeWriter().Visit(syntaxTree.GetRoot());
            }
            private static int Indent = 0;
            public override void Visit(SyntaxNode node)
            {
                Indent++;
                var indents = new String(' ', Indent * 2);
                Console.WriteLine(indents + node.CSharpKind());
                base.Visit(node);
                Indent--;
            }
        }
