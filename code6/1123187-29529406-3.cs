    string code = ReadText("Case6.cs"); // get source code as string for a class
    var tree = CSharpSyntaxTree.ParseText(code);
    CompilationUnitSyntax root = (CompilationUnitSyntax)tree.GetRoot();
    Compilation compilation = CSharpCompilation.Create("assembly", syntaxTrees: new[] { tree }, references: new[]
    {
        mscorlib = MetadataReference.CreateFromAssembly(typeof(object).Assembly),
                   MetadataReference.CreateFromAssembly(typeof(Stack<>).Assembly)
    });
    var semanticModel = compilation.GetSemanticModel(tree);
    var myRewriter = new MyRewriter(semanticModel);
    var result = myRewriter.Visit(tree.GetRoot());
    var str = result.ToString();
    // below are classes for Rewriter
    public class MyRewriter : CSharpSyntaxRewriter
    {
        private SemanticModel semanticModel;
        public MyRewriter(SemanticModel semanticModel)
        {
            this.semanticModel = semanticModel;
        }
        public override SyntaxNode VisitSwitchStatement(SwitchStatementSyntax node)
        {
            var result =  base.VisitSwitchStatement(node);
            // detect your case:
            // first check if the expression in switch is bool type?
            var typeInfo = semanticModel.GetTypeInfo(node.Expression);
            if(typeInfo.Type.SpecialType != SpecialType.System_Boolean)
            {
                return result;
            }
            // okie we make the conversion here
            // find true statement
            var trueSection = node.Sections
                    .First(f => f.Labels.First().ToString().Contains("true"));
            var falseSection = node.Sections
                    .First(f => f.Labels.First().ToString().Contains("false"));
            var trueStatement = trueSection.Statements.Count == 1
                            ? trueSection.Statements.First()
                            : SyntaxFactory.Block(trueSection.Statements);
            var falseStatement = falseSection.Statements.Count == 1
                            ? falseSection.Statements.First()
                            : SyntaxFactory.Block(falseSection.Statements);
            var ifStatement = SyntaxFactory.IfStatement(node.Expression,
                trueStatement,
                SyntaxFactory.ElseClause(falseStatement));
            //NOTE that: this class will remove all break statements
            // it will not be correct if break in loop, you can base on that to 
            // write more accurately
            var breakRemover = new BreakRemover();
            result = breakRemover.Visit(ifStatement);
                
            return result;
        }
    }
    public class BreakRemover : CSharpSyntaxRewriter
    {
        public override SyntaxNode VisitBreakStatement(BreakStatementSyntax node)
        {
            // should add further check to make sure break statement is in
            // switch, the idea is find closest ancestor must be switch (not
            // for, foreach, while, dowhile)
            return SyntaxFactory.EmptyStatement();
        }
    }
