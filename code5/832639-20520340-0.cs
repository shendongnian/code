    public static object GetValue(string propertyName)
    {
    	var property = typeof(Names).GetField(propertyName);
    	return property.GetValue(null);
    }
    
    private static void Main(string[] args)
    {
    	string res = GetValue("One") as string;   // "Value of One"
    
    	Console.Read();
    }
