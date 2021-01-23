    public static class EnumsHelper
    {
    	public static T GetAttributeOfType<T>(this Enum enumVal) where T : Attribute
    	{
    		var typeInfo = enumVal.GetType().GetTypeInfo();
    		var v = typeInfo.DeclaredMembers.First(x => x.Name == enumVal.ToString());
    		return v.GetCustomAttribute<T>();
    	}
    }
