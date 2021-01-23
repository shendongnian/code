    public static class ConversionUtility
    {
    	private static Dictionary<Type, Dictionary<Type, IConverter>> Converters = new Dictionary<Type, Dictionary<Type, IConverter>>();
    	
    	public static void RegisterConversion<TIncoming, TOutgoing>(Func<TIncoming, TOutgoing> conversionFunction)
    	{
    		if (!Converters.ContainsKey(typeof(TIncoming)))
    		{
    			Converters[typeof(TIncoming)] = new Dictionary<Type, IConverter>();
    		}
    		
    		Converters[typeof(TIncoming)].Add(typeof(TOutgoing), new Converter<TIncoming, TOutgoing>(conversionFunction));
    	}
    	
    	public static TOutgoing Convert<TOutgoing>(object obj)
    	{
    		Type incomingType = obj.GetType();
    	
    		IConverter converter = Converters[incomingType][typeof(TOutgoing)];
    		
    		return (TOutgoing)converter.Convert(obj);
    	}
    }
