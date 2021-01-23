    Dictionary<string, Type> DerivedOfferings{get;set;}
    ... //somewhere in the setup of your manager.
    foreach (Type t in AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(IEmtRequestProcessor)))))
    {
        DerivedOfferings.Add(t.Name, t);
    }
    //provide list of options to users.
    IList<string> GetOfferingOptions(){
        return DerivedOfferings.Keys.ToList();
    }
    ...
    public BaseClass GetOffering(string name){
        return (BaseClass)Activator.CreateInstance(DerivedOfferings[type]);
    }
