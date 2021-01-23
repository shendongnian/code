    public static class DynamicInterop
    {
	    public static DynamicInterop()
	    {
            var enumsDict = new ExpandoObject() as IDictionary<string, Object>;
            // Get all enum types from interop assembly
            var interopEnums = GetInteropAssembly()
                .GetTypes()
                .Where(type =>
                    typeof(Enum).IsAssignableFrom(type));
            // For all enum types create a member in the enums dynamic object
            foreach (var type in interopEnums)
            {
                var curEnum = new ExpandoObject() as IDictionary<string, Object>;
                // Get Enum value name and values as KeyValuePairs
                var enumKeyValues = Enum
                    .GetNames(type)
                    .Zip(Enum.GetValues(type).Cast<Object>(), 
                        (key, value) =>
                            new KeyValuePair<String, Object>(key, value));
                // Create members for every enum value name-value pair
                foreach (var keyValue in enumKeyValues)
                {
                    curEnum.Add(keyValue.Key, keyValue.Value);
                }
                enumsDict.Add(type.Name, curEnum);
            }
            DynamicInterop.Enums = enumsDict;
	    }
	    public static dynamic CreateWordApp()
	    {
            throw new NotImplementedException();
	    }
	
	    public static dynamic Enums
	    {
		    get;
		    private set;
	    }
    }
