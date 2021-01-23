    public override void Initialize(AnalysisContext context)
    {
        context.RegisterSyntaxNodeAction(AnalyzeConstDeclaration, SyntaxKind.FieldDeclaration);
    }
    public static void AnalyzeConstDeclaration(SyntaxNodeAnalysisContext context)
    {
         var solution = context.GetSolution();
    }
