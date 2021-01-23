    public static String GetEnumMemberValue<T>(T value)
    	where T : struct, IConvertible
    {
    	return typeof(T)
    		.GetTypeInfo()
    		.DeclaredMembers
    		.SingleOrDefault(x => x.Name == value.ToString())
    		?.GetCustomAttribute<EnumMemberAttribute>(false)
    		?.Value;
    }
