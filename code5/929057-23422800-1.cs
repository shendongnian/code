     var root = await document.GetSyntaxRootAsync(cancellationToken); (root)
     var token = root.FindToken(span.Start); 
     var node = root.FindNode(span);
    
     if (node.IsKind(SyntaxKind.VariableDeclarator))
     {
       if (token.IsKind(SyntaxKind.IdentifierToken))
       {
            var variable = (VariableDeclaratorSyntax)node;
            string newName = variable.Identifier.ValueText;
            string NameDone = String.Empty;
            for (int i = 0; i < newName.Length; i++)
            {
                 NameDone = NameDone.ToString() + char.ToUpper(newName[i]);
            }
    
            var leading = variable.Identifier.LeadingTrivia;
            var trailing = variable.Identifier.TrailingTrivia;
    
            VariableDeclaratorSyntax newVariable = variable.WithIdentifier(SyntaxFactory.Identifier(leading, NameDone, trailing));
    
            var newRoot = root.ReplaceNode(variable, newVariable);
            return new[] { CodeAction.Create("Make upper", document.WithSyntaxRoot(newRoot)) };
       }
    }
