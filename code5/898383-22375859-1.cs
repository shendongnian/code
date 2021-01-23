    private static void General(Type enumType)
    {
    	if (!enumType.IsEnum)
    		throw new ArgumentException("Not an enum type");
    		
    	var values = enumType.GetFields();
    	
    	var code = values.First(f => f.Name == "Code");
    	var info = values.First(f => f.Name == "Info");
    	
    	string codeString = code.GetCustomAttributes(false).OfType<StringValue>().First().Name;
    	string infoString = info.GetCustomAttributes(false).OfType<StringValue>().First().Name;
    	
    	Console.WriteLine(codeString);
    	Console.WriteLine(infoString);
    }
