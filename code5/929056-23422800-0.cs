    var localDeclarationConst = node as LocalDeclarationStatementSyntax;
    if (localDeclarationConst != null &&
        localDeclarationConst.Modifiers.Any(SyntaxKind.ConstKeyword)
        )
    {
    foreach (VariableDeclaratorSyntax variable in localDeclarationConst.Declaration.Variables)
    {
         string varName = variable.Identifier.Text;
         if (!varName.Equals(varName.ToUpper()))
         {
            addDiagnostic(Diagnostic.Create(Rule, variable.GetLocation(), "Les constantes doivent être en majusucle"));
         }
    
    }
