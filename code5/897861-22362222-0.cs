    public static void SetEntryAssembly()
    {
    	if (Assembly.GetEntryAssembly() != null)
    	{
    		return;
    	}
    
    	Assembly assembly = Assembly.GetCallingAssembly();
    
    	AppDomainManager manager = new AppDomainManager();
    	FieldInfo entryAssemblyfield = manager.GetType().GetField("m_entryAssembly", BindingFlags.Instance | BindingFlags.NonPublic);
    	if (entryAssemblyfield != null)
    	{
    		entryAssemblyfield.SetValue(manager, assembly);
    	}
    
    	AppDomain domain = AppDomain.CurrentDomain;
    	FieldInfo domainManagerField = domain.GetType().GetField("_domainManager", BindingFlags.Instance | BindingFlags.NonPublic);
    	if (domainManagerField != null)
    	{
    		domainManagerField.SetValue(domain, manager);
    	}
    }
