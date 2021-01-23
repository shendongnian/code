    var tree = CSharpSyntaxTree.ParseText(@"
    public class MyClass {
    public void Method()
    {
        try { }
        catch(Exception e)
        {
            //useless
            throw e;
        }
        try {  }
        catch(Exception e)
        {
            //Some work
            int aVariable = 4;
            throw e;
        }
    }
    }
    ");
    //Finds all catch clauses
    var catchClauses = tree.GetRoot().DescendantNodesAndSelf().OfType<CatchClauseSyntax>();
    //Look at the catch blocks
    var catchBlocks = catchClauses.Select(n => n.DescendantNodes().OfType<BlockSyntax>().First());
    //Filter out the clauses where statements all are only throw statements
    var uselessClauses = catchBlocks.Where(n => n.Statements.All(m => m is ThrowStatementSyntax));
