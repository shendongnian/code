    // This assume perfect parameter
    public int Calculate(string expression)
    {
    
     int result = 0;
     string[] tokens = null;
    
     tokens = expression.Split(" ");
     result = Int32.Parse(tokens[0]);
    
     for (int i = 1; i <= tokens.Length - 1; i += 2) {
       if (tokens[i] == "plus")
         result += Int32.Parse(tokens[i + 1]);
       else if (tokens[i] == "minus")
         result -= Int32.Parse(tokens[i + 1]);
     }
    
     return result;
   }
