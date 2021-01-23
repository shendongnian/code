    public override int VisitLocalDeclarationStatement(
        LocalDeclarationStatementSyntax node)
    {
        return node.Declaration.Variables.Select(Visit).Max();
    }
    public override int VisitVariableDeclarator(VariableDeclaratorSyntax node)
    {
        if (node.Initializer == null)
            return 0;
        return Visit(node.Initializer.Value);
    }
