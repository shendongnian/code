    public Double Calculate(string argExpression)
            {
                //get the user passed string
                string ExpressionToEvaluate = argExpression;
                //pass string in the evaluation object declaration.
                Expression z = new Expression(ExpressionToEvaluate);
                //command to evaluate the value of the **************string expression
                var result = z.Evaluate();
                Double results = Convert.ToDouble(result.ToString());
    
                return results;
    
            }
 
  
