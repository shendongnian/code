    var consoleWriteLine = Syntax.MemberAccessExpression(
          SyntaxKind.SimpleMemberAccessExpression,
          Syntax.IdentifierName("Console"),
          name: Syntax.IdentifierName("WriteLine"));
      var arguments = Syntax.ArgumentList (
          Syntax.SeparatedList (
              new[]
              {
                  Syntax.Argument (
                      Syntax.LiteralExpression (
                          SyntaxKind.StringLiteralExpression,
                          Syntax.Literal (@"""Goodbye everyone!""", "Goodbye everyone!")))
              }));
      var consoleWriteLineStatement = Syntax.ExpressionStatement (Syntax.InvocationExpression (consoleWriteLine, arguments));
      var voidType = Syntax.ParseTypeName ("void");
      var method = Syntax.MethodDeclaration (voidType, "Method").WithBody (Syntax.Block(consoleWriteLineStatement));
      var intType = Syntax.ParseTypeName ("int");
      var getterBody = Syntax.ReturnStatement (Syntax.DefaultExpression (intType));
      var getter = Syntax.AccessorDeclaration (SyntaxKind.GetAccessorDeclaration, Syntax.Block (getterBody));
      var property = Syntax.PropertyDeclaration (intType, "Property").WithAccessorList (Syntax.AccessorList (Syntax.SingletonList (getter)));
      var @class = Syntax.ClassDeclaration ("MyClass").WithMembers (Syntax.List (new MemberDeclarationSyntax[] { method, property }));
      var cw = new CustomWorkspace();
      cw.Options.WithChangedOption (CSharpFormattingOptions.IndentBraces, true);
      var formattedCode = Formatter.Format (@class, cw);
      Console.WriteLine (formattedCode.ToFullString());
