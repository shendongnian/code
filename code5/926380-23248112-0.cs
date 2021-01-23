    public void AnalyzeNode(SyntaxNode node, SemanticModel semanticModel, Action<Diagnostic> public void AnalyzeNode(SyntaxNode node, SemanticModel semanticModel, Action<Diagnostic> addDiagnostic, CancellationToken cancellationToken)
        {
            var localDeclaration = (LocalDeclarationStatementSyntax)node;
            if (localDeclaration.Declaration.Type.IsVar) return;
            var variable = localDeclaration.Declaration.Variables.First();
            var initialiser = variable.Initializer;
            if (initialiser == null) return;
            var variableTypeName = localDeclaration.Declaration.Type;
            var variableType = semanticModel.GetTypeInfo(variableTypeName).ConvertedType;
            var initialiserInfo = semanticModel.GetTypeInfo(variable.Initializer.Value);
            var typeOfRightHandSideOfDeclaration = initialiserInfo.Type;
            if (Equals(variableType, typeOfRightHandSideOfDeclaration))
            {
                addDiagnostic(Diagnostic.Create(Rule, node.GetLocation(), localDeclaration.Declaration.Variables.First().Identifier.Value));
            }
        }
