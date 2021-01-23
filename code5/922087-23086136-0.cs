		var myValue = MyEnum.Value3;
		
		var stringRepresentation = myValue.ToString();
		var intRepresentation = (int)myValue;
		
		Console.WriteLine("String-Value: \"{0}\"", stringRepresentation);
		Console.WriteLine("Int-Value: {0}", intRepresentation);
		
		var parsedFromString = (MyEnum)Enum.Parse(typeof(MyEnum), stringRepresentation);
		var parsedFromInt = (MyEnum)Enum.Parse(typeof(MyEnum), intRepresentation.ToString());
		
		Console.WriteLine("Parsed from string: {0}", parsedFromString);
		Console.WriteLine("Parsed from int: {0}", parsedFromInt);
