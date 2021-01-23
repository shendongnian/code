    public class RegexDemo 
    {
        public static void main(String[] args) 
    	{        
    		Regex p = new Regex(" [a-z]{3} ");
    		var groups = p.Match("Alice has a cat ").Groups; //matcher which will analyze given text
    		foreach(var group in groups)
    		{
    			Console.WriteLine(group.Value);
    		}
    	}
    }
