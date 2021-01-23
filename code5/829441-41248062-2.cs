    public static class AutoMapperConfiguration
    {
    	public static void Configure()
    	{
    		Mapper.Initialize(ConfigAction);
    	}
    
    	public static Action<IMapperConfigurationExpression> ConfigAction = cfg =>
    	{
    		cfg.AddProfile<SomeProfile>();            
    		cfg.AddProfile<SomeOtherProfileProfile>();
    	};
    }
