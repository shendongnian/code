    public class NameAllParametersRewriter : CSharpSyntaxRewriter
    {
        private readonly SemanticModel _semanticModel;
        public NameAllParametersRewriter(Document document)
        {
            _semanticModel = document.GetSemanticModelAsync().Result;
        }
        public override SyntaxNode VisitObjectCreationExpression(
            ObjectCreationExpressionSyntax node)
        {
            var baseResult = (ObjectCreationExpressionSyntax)
                base.VisitObjectCreationExpression(node);
            var ctorSymbol = _semanticModel.GetSymbolInfo(node).Symbol as IMethodSymbol;
            if (ctorSymbol == null)
                return baseResult;
            var newArgumentListArguments = new SeparatedSyntaxList<ArgumentSyntax>();
            for (int i = 0; i < baseResult.ArgumentList.Arguments.Count; i++)
            {
                var oldArgumentSyntax = baseResult.ArgumentList.Arguments[i];
                var parameterName = ctorSymbol.Parameters[i].Name;
                var identifierSyntax = SyntaxFactory.IdentifierName(parameterName);
                var nameColonSyntax = SyntaxFactory
                    .NameColon(identifierSyntax)
                    .WithTrailingTrivia(SyntaxFactory.Whitespace(" "));
                var newArgumentSyntax = SyntaxFactory.Argument(
                    nameColonSyntax, 
                    oldArgumentSyntax.RefOrOutKeyword, 
                    oldArgumentSyntax.Expression);
                
                newArgumentListArguments = newArgumentListArguments.Add(newArgumentSyntax);
            }
            return baseResult
                .WithArgumentList(baseResult.ArgumentList
                    .WithArguments(newArgumentListArguments));
        }
    }
