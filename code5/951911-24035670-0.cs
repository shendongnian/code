    // Using the CLSID
    Executable exExpressionTask = 
	pkg.Executables.Add("Microsoft.SqlServer.Dts.Tasks.ExpressionTask.ExpressionTask, Microsoft.SqlServer.ExpressionTask, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91");
    TaskHost thExpressionTask = exExpressionTask as TaskHost;
    ExpressionTask expressionTask = thExpressionTask.InnerObject as ExpressionTask;
    
    // Set the expression.
    expressionTask.Expression = @"10>0";
    
    // Get the expression.
    string expression = expressionTask.Expression;
    
    // Validate the expression.
    string str = expressionTask.ValidateExpression(null);
