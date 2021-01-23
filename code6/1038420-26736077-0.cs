    public class MyResolver : DataContractResolver
    {
    	private XmlDictionaryString _typeName;
        private XmlDictionaryString _typeNamespace;
    	
    	public PooledPricesResolver()
    	{
    		XmlDictionary dictionary = new XmlDictionary();
    		_typeName = dictionary.Add("T2");
    		_typeNamespace = dictionary.Add("MyNamespace");
    	}
    
    	public override bool TryResolveType(Type type, Type declaredType, DataContractResolver knownTypeResolver, out XmlDictionaryString typeName, out XmlDictionaryString typeNamespace)
    	{
    		if (declaredType == typeof(T1))
    		{
    			typeName = _typeName; //null;
    			typeNamespace = _typeNamespace; //null
    			return true;
    		}
    
    		return knownTypeResolver.TryResolveType(type, declaredType, null, out typeName, out typeNamespace);
    	}
    
    	public override Type ResolveName(string typeName, string typeNamespace, Type declaredType, DataContractResolver knownTypeResolver)
    	{
    		if (typeName == "T2" && typeNamespace == "MyNamespace")
    		{
    		    return typeof(T1);
    		}
    
    		return knownTypeResolver.ResolveName(typeName, typeNamespace, declaredType, null) ?? declaredType;
    	}
    }
