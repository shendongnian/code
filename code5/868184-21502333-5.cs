    public string Evaluate(string expression)
    {
    	var interpreter = new Interpreter();
    	interpreter.SetVariable("DefaultSettings", Settings.Default);
    	return interpreter.Eval<string>(expression);
    }
