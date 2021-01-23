    public static void Match(string input, int k)
    {
        Regex regex = new Regex(@"^(?=.{"+k+"}$)a*b*$");
    	Console.WriteLine(regex.IsMatch(input));
        
    }
    
