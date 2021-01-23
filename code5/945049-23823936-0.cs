    Dim ThisIdentifier = CType(TheFormatString.Expression, IdentifierNameSyntax)
    If ThisIdentifier Is Nothing Then Exit Sub
    Dim ConstValue = semanticModel.GetConstantValue(ThisIdentifier, cancellationToken)
    If ConstValue.HasValue = False Then Exit Sub
    Dim FoundSymbol = semanticModel.LookupSymbols(TheFormatString.Expression.Span.Start, name:=ThisIdentifier.Identifier.Text)(0)
    Dim VariableDeclarationSite = TryCast(FoundSymbol.DeclaringSyntaxReferences(0).GetSyntax.Parent, VariableDeclaratorSyntax)
    If VariableDeclarationSite Is Nothing Then Exit Sub
    Dim TheValueOfTheVariable = VariableDeclarationSite.Initializer.Value
