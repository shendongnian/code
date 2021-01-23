    public enum Manufacturer
    {
    	[Description("I did")]
    	Idid = 1,
    	[Description("Another company or person")]
    	AnotherCompanyOrPerson = 2
    }
    
    /// <summary>
    /// Get the enum description value
    /// </summary>
    /// <param name="en"></param>
    /// <returns></returns>
    public static string ToEnumDescription(this Enum en) //ext method
    {
    	Type type = en.GetType();
    	MemberInfo[] memInfo = type.GetMember(en.ToString());
    	if (memInfo != null && memInfo.Length > 0)
    	{
    		object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
    		if (attrs != null && attrs.Length > 0)
    			return ((DescriptionAttribute)attrs[0]).Description;
    	}
    	return en.ToString();
    }
