    [Flags]
    enum MyEnum
    {
        Manual = 1,
        Site = 2,
        Api = 4,
        Custom = 8
    }
	static void Main(string[] args)
	{
    	// SortedSet is not necessary but it has convenient Min and Max properties.
    	SortedSet<MyEnum> enumValues = new SortedSet<MyEnum>();
	    foreach (MyEnum e in Enum.GetValues(typeof(MyEnum)))
	        enumValues.Add(e);
    	// enumValues.Max * 2 to check all combinations including the last flag.
    	for (int i = (int)enumValues.Min + 1; i < (int)enumValues.Max * 2; i++)
    	{
        	MyEnum currentlyChecked = (MyEnum)i;
        	// if there's no equivalent of i defined in MyEnum
        	if (!enumValues.Contains(currentlyChecked))
        	{
            	string representation = "";
            	// Iterate over all MyEnum flags which underlying value is lower than i
            	// and add those flags which are contained in (MyEnum)i to the string representation
            	// of the value missing from the MyEnum enumeration.
            	foreach (MyEnum lowerValue in enumValues.Where(e => (int)e < i))
            	{
                	if (currentlyChecked.HasFlag(lowerValue))
                    	representation += lowerValue.ToString();
            	}
                if (String.IsNullOrEmpty(representation))
                    representation = "[MISSING FLAG]";
	            Console.WriteLine("Missing value: {0} - {1}", i, representation);
        	}
	    }
	}
