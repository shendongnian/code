    private void SerializeAndBack()
    {
    	var item = new ScheduledServiceHost
    		{
    			ScheduledServices = new List<ScheduledService>
    				{
    					new AlphaService {Alpha_Age = 32, Alpha_Name = "John Jones", ServiceName = "FirstService"},
    					new BetaService {Beta_Company = "Ajax Inc.", Beta_IsOpen = true, ServiceName = "SecondService"},
    				}
    		};
    
    	var xmlText = XmlSerializeToString( item );
    	var newObj = XmlDeserializeFromString( xmlText, typeof( ScheduledServiceHost ) );
    }
    
    public static string XmlSerializeToString( object objectInstance, params Type[] extraTypes )
    {
    	var sb = new StringBuilder();
    
    	using ( TextWriter writer = new StringWriter( sb ) )
    	{
    		var serializer = new XmlSerializer( objectInstance.GetType(), extraTypes );
    		serializer.Serialize( writer, objectInstance );
    	}
    
    	return sb.ToString();
    }
    
    public static object XmlDeserializeFromString( string objectData, Type type )
    {
    	using ( var reader = new StringReader( objectData ) )
    	{
    		return new XmlSerializer( type ).Deserialize(reader);
    	}
    }
