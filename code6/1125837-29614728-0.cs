    foreach (var item in root.DescendantNodes()
    .OfType<InvocationExpressionSyntax>())
                 {
                    var expr = item.Expression;
                    if (expr is IdentifierNameSyntax)
                    {
                        IdentifierNameSyntax identifierName = r as IdentifierNameSyntax; // identifierName is your method name
                    }
                    if (expr is MemberAccessExpressionSyntax)
                    {
                        MemberAccessExpressionSyntax memberAccessExpressionSyntax = r as MemberAccessExpressionSyntax;
                        //memberAccessExpressionSyntax.Name is your method name
                    }
                }
