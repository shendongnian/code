    class NestingLevelVisitor : SyntaxVisitor<int>
    {
        public override int DefaultVisit(SyntaxNode node)
        {
            throw new NotSupportedException();
        }
        public override int VisitMethodDeclaration(MethodDeclarationSyntax node)
        {
            return Visit(node.Body);
        }
        public override int VisitBlock(BlockSyntax node)
        {
            return node.Statements.Select(Visit).Max();
        }
        public override int VisitExpressionStatement(ExpressionStatementSyntax node)
        {
            return 0;
        }
        public override int VisitIfStatement(IfStatementSyntax node)
        {
            int result = Visit(node.Statement);
            if (node.Else != null)
            {
                int elseResult = Visit(node.Else.Statement);
                result = Math.Max(result, elseResult);
            }
            return result + 1;
        }
    }
