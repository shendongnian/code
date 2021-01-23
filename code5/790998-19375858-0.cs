    /// <summary>
    /// Get the whilespace separated values of an enum
    /// </summary>
    /// <param name="en"></param>
    /// <returns></returns>
    public static string ToEnumWordify(this Enum en)
    {
    	Type type = en.GetType();
    	MemberInfo[] memInfo = type.GetMember(en.ToString());
    	string pascalCaseString = memInfo[0].Name;
    	Regex r = new Regex("(?<=[a-z])(?<x>[A-Z])|(?<=.)(?<x>[A-Z])(?=[a-z])");
    	return r.Replace(pascalCaseString, " ${x}");
    }
