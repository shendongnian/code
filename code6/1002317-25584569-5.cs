    class Rewriter : CSharpSyntaxRewriter
    {
        public override SyntaxNode VisitForStatement(ForStatementSyntax node)
        {
            // update the current node with the new condition and statement
            return node.WithCondition(
                SyntaxFactory.ParseExpression("i>=0")
            ).WithStatement(
                SyntaxFactory.ParseStatement(@"{
                  Console.WriteLine(i);
                  Console.WriteLine(i*2);
                }")
            );
        }
    }
