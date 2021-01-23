    public void Main()
    {
    	var item = Sitecore.Context.Item;
    
    	if (item.TemplateID.Equals(GetSitecoreTypeTemplateId<IRateableItem>()))
    	{
    		// item is of the IRateableItem type
    	}
    }
    
    private ID GetSitecoreTypeTemplateId<T>() where T : class
    {
    	// Get the GlassMapper context
    	var context = GetGlassContext();
    
    	// Retrieve the SitecoreTypeConfiguration for type T
    	var sitecoreClass = context[typeof(T)] as SitecoreTypeConfiguration;
    
    	return sitecoreClass.TemplateId;
    }
    
    private SitecoreService GetSitecoreService()
    {
    	return new SitecoreService(global::Sitecore.Context.Database);
    }
    
    private Glass.Mapper.Context GetGlassContext()
    {
    	return GetSitecoreService().GlassContext;
    }
