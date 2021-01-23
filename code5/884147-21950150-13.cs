    public int EvaluateExpression(string math )
        {
           return Convert.ToInt32(math);
        }
........................
    String math = "100 * 5 - 2"; 
    
    int result = EvaluateExpression(math );
    
    Console.WriteLine(result );
