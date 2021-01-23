    public class RewriterPartial : CSharpSyntaxRewriter
    {
        private readonly CSharpCompilation _compilation;
        public RewriterPartial(CSharpCompilation compilation, SemanticModel model)
        {
            this._compilation = compilation;
        }
        public override SyntaxNode VisitClassDeclaration(ClassDeclarationSyntax node)
        {
            //Visit the deepest nodes before modifying the tree.
            var newNode = (ClassDeclarationSyntax)base.VisitClassDeclaration(node);
            if (!newNode.Modifiers.Any(SyntaxKind.PartialKeyword))
            {
                newNode = newNode.WithModifiers(
                    SyntaxFactory.TokenList(
                        SyntaxFactory.Token(SyntaxKind.PartialKeyword)));
            }
            return newNode;
        }
        public override SyntaxNode VisitMethodDeclaration(MethodDeclarationSyntax node)
        {
            var model = _compilation.GetSemanticModel(node.SyntaxTree);
            var symbol = model.GetDeclaredSymbol(node);
            //Do whatever you need to here
            return node;
        }
    }
