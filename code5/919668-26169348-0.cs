       public List<string> GetParameters(string expression) {
           List<string> parameters = new List<string>();
           Random random = new Random();
           NCalc.Expression e = new NCalc.Expression(expression);
    
           e.EvaluateFunction += delegate(string name, NCalc.FunctionArgs args) {
               args.EvaluateParameters();
               args.Result = random.Next(0, 100);
           };
           e.EvaluateParameter += delegate(string name, NCalc.ParameterArgs args) {
               parameters.Add(name);
               args.Result = random.Next(0, 100);
           };
           try {
               e.Evaluate();
               }
           catch {
                }
           return parameters;
        }
