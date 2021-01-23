    public async Task<IEnumerable<CodeAction>> GetFixesAsync(Document document, TextSpan span, IEnumerable<Diagnostic> diagnostics, CancellationToken cancellationToken)
        {
            var root = await document.GetSyntaxRootAsync(cancellationToken);
            var token = root.FindToken(span.Start);
            var allTrivia = token.GetAllTrivia();
            foreach(var singleTrivia in allTrivia)
            {
                if (singleTrivia.IsKind(SyntaxKind.SingleLineCommentTrivia))
                {
                    var commentContent = singleTrivia.ToString().Replace("//", string.Empty);
                    var newComment = SyntaxFactory.Comment(string.Format("/*{0}*/", commentContent));
                    var newRoot = root.ReplaceTrivia(singleTrivia, newComment);
                    return new[] { CodeAction.Create("Convert to multiline", document.WithSyntaxRoot(newRoot)) };
                }
            }           
            return null;
        }
