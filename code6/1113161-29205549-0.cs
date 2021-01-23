    protected virtual IEnumerable<IRegistration> GetComponentRegistrations()
            {
                return new IRegistration[]
    				{
    					Classes.FromAssembly(GetAssemblyNamed(MyAssembly))
    						   .BasedOn<IMyComponent>()
    						   .If(x => x.IsContructable()) // this is it
    						   .WithServiceDefaultInterfaces()
    				};
            }
    
    public static class TypeHelpers
    	{
    		public static bool IsContructable(this Type t)
    		{
    			return !t.IsAbstract && !t.ContainsGenericParameters;
    		}
    	}
