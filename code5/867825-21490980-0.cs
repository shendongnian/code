    static Dictionary<string, char> charMap = new Dictionary<string, char>()
       {
            {"alpha", 'a'}, {"beta", 'Y'}, {"gamma", 'g'}, {"delta", '='}
       };
    	   
    void Main()
    {
    	var input = "alpha beta gamma delta";
    	
    	var result = CharMap(input);
    }
    
    public string CharMap(string input)
    {
    	var result = "";
    	
    	foreach (var item in input.Split(' '))
    	{
    		result += charMap[item];	
    	}
    	
    	return result;
    }
