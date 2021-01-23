    public class RegexDemo 
    {
        public static void main(String[] args) 
    	{        
    		Regex p = new Regex(" [a-z]{3} ");
    		var matches= p.Matches("Alice has a cat "); //matcher which will analyze given text
    		foreach(var match in matches)
    		{
    			Console.WriteLine(match .Value);
    		}
    	}
    }
