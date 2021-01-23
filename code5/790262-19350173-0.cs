    public List<IBusinessObject> RetrieveAllBusinessObjects()
    {
        var businessObjectType= typeof(IBusinessObject);
    
        List<Type> implementationsOfBusinessObject = AppDomain.CurrentDomain.GetAssemblies()
             .SelectMany(s => s.GetTypes())
             .Where(businessObjectType.IsAssignableFrom).ToList();
    
        return implementationsOfBusinessObject.Select(t => (IBusinessObject)Activator.CreateInstance(t)).ToList();
    }
