    public void AnalyzeSyntaxTree(SyntaxTree tree, Action<Diagnostic> addDiagnostic, CancellationToken cancellationToken)
        {
            var root = tree.GetRoot();
            var trivia = root.DescendantTrivia();
            var listOfSingleLineComments = trivia.Where(x => x.IsKind(SyntaxKind.SingleLineCommentTrivia)).ToList();
            foreach(var singleComment in listOfSingleLineComments)
            {
                addDiagnostic(Diagnostic.Create(Rule, singleComment.GetLocation(), "Single comment"));
            }
        }
