    var forStmt = root.DescendantNodes().OfType<ForStatementSyntax>().Single();
    var rewritten = root.ReplaceNode(forStmt,
        forStmt.WithCondition(
            SyntaxFactory.ParseExpression("i>=0")
        ).WithStatement(
            SyntaxFactory.ParseStatement(@"    {
        Console.WriteLine(i);
        Console.WriteLine(i*2);
    }
")
        ));
