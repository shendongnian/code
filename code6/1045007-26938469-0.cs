    using System.Linq;
    ...
    public List<AbstractCWThirdPartyConsumer> GetAllProviders()
    {
        IEnumerable<Assembly> referencedAssemblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies().Select(Assembly.Load);
    
        List<AbstractCWThirdPartyConsumer> listOfAllProcessors = new List<AbstractCWThirdPartyConsumer>();
        foreach (Assembly assembly in referencedAssemblies)
        {
            foreach(Type type in assembly.ExportedTypes)
    		{
    		    if (IsSameOrSubclass(typeof(AbstractCWThirdPartyConsumer), type))
                {
                 //AbstractCWThirdPartyConsumer proc = (AbstractCWThirdPartyConsumer)Activator.CreateInstance(type);
                 //listOfAllProcessors.Add(proc);
                } 
    	    }
        }
        return listOfAllProcessors;
    }
    
    public bool IsSameOrSubclass(Type potentialBase, Type potentialDescendant)
    {
        return potentialDescendant.IsSubclassOf(potentialBase);
    }
