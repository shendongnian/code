    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
    	..... YOU Code For Determine Real Type of Json Record .......
    	
    	// 1. Correct ContractResolver for you derived type
    	var contract = serializer.ContractResolver.ResolveContract(DeterminedType);
    	if (converter != null && !typeDeserializer.Type.IsAbstract && converter.GetType() == GetType())
    	{
    		contract.Converter = null; // Clean Wrong Converter grabbed by DefaultContractResolver from you base class for derived class
    	}
    	
    	// Deserialize in general way			
    	var jTokenReader = new JTokenReader(jObject);
    	var result = serializer.Deserialize(jTokenReader, DeterminedType);
    	
    	return (result);
    }
