    public Startup(IHostingEnvironment env)
    {
    	Mapper.Initialize(x =>
    	{
    		Project1.AutoMapperConfiguration.ConfigAction.Invoke(x);
    		Project2.AutoMapperConfiguration.ConfigAction.Invoke(x);
    		Project3.AutoMapperConfiguration.ConfigAction.Invoke(x);
    	});
    }
