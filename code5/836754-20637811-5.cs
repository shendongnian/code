    public static TOutgoing Convert<TOutgoing>(object obj)
    {
    	Type incomingType = obj.GetType();
    
        var conversionOperator = incomingType.GetMethods(BindingFlags.Static | BindingFlags.Public)
        	.Where(m => m.Name == "op_Explicit")
        	.Where(m => m.ReturnType == typeof(TOutgoing))
        	.Where(m => m.GetParameters().Length == 1 && m.GetParameters()[0].ParameterType == incomingType)
        	.FirstOrDefault();
    
        if (conversionOperator != null)
            return (TOutgoing)conversionOperator.Invoke(null, new object[]{obj});
    
        throw new Exception("No conversion operator found");
    }
