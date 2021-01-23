    [DiagnosticAnalyzer]
    [ExportDiagnosticAnalyzer(DiagnosticId, LanguageNames.CSharp)]
    internal class DiagnosticAnalyzer : ISyntaxTreeAnalyzer
    {
        internal const string DiagnosticId = "CommentChanger";
        internal const string Description = "Single comments should be multiline comments";
        internal const string MessageFormat = "'{0}' should be multiline";
        internal const string Category = "Naming";
        internal static DiagnosticDescriptor Rule = new DiagnosticDescriptor(DiagnosticId, Description, MessageFormat, Category, DiagnosticSeverity.Warning);
        public ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics
        {
            get { return ImmutableArray.Create(Rule); }
        }
        public void AnalyzeSyntaxTree(SyntaxTree tree, Action<Diagnostic> addDiagnostic, CancellationToken cancellationToken)
        {
            var root = tree.GetRoot();
            var trivia = root.DescendantTrivia();
            var a = trivia.Where(x => x.IsKind(SyntaxKind.SingleLineCommentTrivia)).ToList();
            foreach(var b in a)
            {
                addDiagnostic(Diagnostic.Create(Rule, b.GetLocation(), "Single comment"));
            }
        }
    }
