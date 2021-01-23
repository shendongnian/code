    byte[] bytes = <HERE I LOAD THE DLL>
    Assembly asb = Assembly.Load(bytes);
    
    AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
    AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve += CurrentDomain_ReflectionOnlyAssemblyResolve;
    IEnumerable<Type> types = asb.GetExportedTypes().Where(w => w.IsSubclassOf(typeof(App)));
    AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve -= CurrentDomain_ReflectionOnlyAssemblyResolve;
    AppDomain.CurrentDomain.AssemblyResolve -= CurrentDomain_AssemblyResolve;
    
    if(types.Count() > 0)
    {
    	Type type = types.FirstOrDefault();
    
    	if( type == null )
    		return false;
    
    	app.AppClass = (App)Activator.CreateInstance(type);
    	return true;
    }
