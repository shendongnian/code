    public virtual string GetEnumName(object value)
    {
    	if (value == null)
    	{
    		throw new ArgumentNullException("value");
    	}
    	if (!this.IsEnum)
    	{
    		throw new ArgumentException(Environment.GetResourceString("Arg_MustBeEnum"), "enumType");
    	}
    	Type type = value.GetType();
    	if (!type.IsEnum && !Type.IsIntegerType(type))
    	{
    		throw new ArgumentException(Environment.GetResourceString("Arg_MustBeEnumBaseTypeOrEnum"), "value");
    	}
    	Array enumRawConstantValues = this.GetEnumRawConstantValues();
    	int num = Type.BinarySearch(enumRawConstantValues, value);
    	if (num >= 0)
    	{
    		string[] enumNames = this.GetEnumNames();
    		return enumNames[num];
    	}
    	return null;
    }
