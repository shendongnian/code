    CodeEntryPointMethod start = new CodeEntryPointMethod();
    CodeMethodInvokeExpression cs1 = new CodeMethodInvokeExpression(
    new CodeTypeReferenceExpression("System.Console"),
    "WriteLine", new CodePrimitiveExpression("Hello World!"));
    start.Statements.Add(cs1);
