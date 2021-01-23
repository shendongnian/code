    [AttributeUsage(AttributeTargets.Field)]
    public sealed class DataBaseValueAttribute : Attribute
    {
    	private object _value;
    	public DataBaseValueAttribute(object value)
    	{
    		_value = value;
    	}
    
    	public object GetValue()
    	{
    		return _value;
    	}
    }
    
    Type tipo = typeof(YourType);
    FieldInfo fi = tipo.GetField("fieldName");
    
    Atributos.DataBaseValueAttribute[] attribs = (Atributos.DataBaseValueAttribute[])fi.GetCustomAttributes(typeof(Atributos.DataBaseValueAttribute), false);
    if (attribs.Count > 0) {
    	return attribs(0).GetValue();
    } else {
    	return null;
    }
