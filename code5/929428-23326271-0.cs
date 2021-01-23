    public class FindOverrides : CSharpSyntaxWalker
    {
        public override void VisitMethodDeclaration(MethodDeclarationSyntax node)
        {
            base.VisitMethodDeclaration(node);
            if (node.Identifier.Text == "Equals" 
                && node.Modifiers.Any(m => m.Text == "override"))
            {
                // found an override of Equals()    
            }
        }
    }
