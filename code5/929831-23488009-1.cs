     if (node.IsKind(SyntaxKind.SimpleAssignmentExpression)) 
     {
            var IncrementationClause = (BinaryExpressionSyntax)node;
            var IncrementionClauseExpressionStatement = IncrementationClause.Parent;
    
            string right = IncrementationClause.Right.ToString(); 
            string left = IncrementationClause.Left.ToString();
    
            var ExpressionNew = SyntaxFactory.ExpressionStatement(IncrementationClause); 
    
             if (right == left + " - 1")
             {
               var BonneIncrementation = SyntaxFactory.PostfixUnaryExpression(SyntaxKind.PostDecrementExpression, IncrementationClause.Left);
               ExpressionNew = SyntaxFactory.ExpressionStatement(BonneIncrementation).WithAdditionalAnnotations(Formatter.Annotation).WithLeadingTrivia(leading).WithTrailingTrivia(trailing); 
              }
              else 
              {
                var BonneIncrementation = SyntaxFactory.PostfixUnaryExpression(SyntaxKind.PostIncrementExpression, IncrementationClause.Left); 
                ExpressionNew = SyntaxFactory.ExpressionStatement(BonneIncrementation).WithAdditionalAnnotations(Formatter.Annotation).WithLeadingTrivia(leading).WithTrailingTrivia(trailing);
              }
                                
              var newRoot = root.ReplaceNode(IncrementionClauseExpressionStatement, ExpressionNew);
    
              return new[] { CodeAction.Create("Convert in the good way of incrementing", document.WithSyntaxRoot(newRoot)) };
               
     }
