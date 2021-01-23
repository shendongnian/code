    public class PropertyRewriter : CSharpSyntaxRewriter
    {
        public override SyntaxNode VisitPropertyDeclaration(PropertyDeclarationSyntax node)
        {
            // 'node' should be still from the original syntax tree here
        
            node = (PropertyDeclarationSyntax)base.VisitPropertyDeclaration(node);
            
            // 'node' might be replaced here
            return node;
        }
    }
