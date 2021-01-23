    public static class AutoMapperConfiguration
    {
    	public static void Configure()
    	{
    		Mapper.Initialize(ConfigAction);
    	}
    
    	public static Action<IMapperConfigurationExpression> ConfigAction = cfg =>
    	{
    		x.AddProfile<SomeProfile>();            
    		x.AddProfile<SomeOtherProfileProfile>();
    	};
    }
