    var paramNames = new List<string>();
    var functionNames = new List<string>();
    expression.Evaluate(
        new EvaluateParameterHandler((s, a) =>
        {
            paramNames.Add(s);
            a.Result = 1; // dummy value
        }),
        new EvaluateFunctionHandler((s, a) =>
        {
            functionNames.Add(s);
            a.Result = 1; // dummy value
        }));
