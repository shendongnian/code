    public static bool IsNull(this string value)
    {
    	var method = new StackTrace().GetFrame(1).GetMethod();
    	Console.WriteLine(String.Format("I was called from '{0}' of class '{1}'", method.Name, method.DeclaringType));
    
    	return string.IsNullOrEmpty(value);
    }
