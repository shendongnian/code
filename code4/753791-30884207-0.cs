    private string findAreaForControllerType(Type controllerType)
    {
        var areaTypes = getAllAreasRegistered();
        foreach (var areaType in areaTypes)
        {
            if (controllerType.Namespace.StartsWith(areaType.Namespace))
            {
                var area = (AreaRegistration)Activator.CreateInstance(areaType);
                return area.AreaName;
            }
        }
        return string.Empty;
    }
    private IEnumerable<Type> getAllAreasRegistered()
    {
        var assembly = getWebEntryAssembly();
        var areaTypes = assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(AreaRegistration)));
            
        return areaTypes;
    }
    static private Assembly getWebEntryAssembly()
    {
        if (System.Web.HttpContext.Current == null ||
            System.Web.HttpContext.Current.ApplicationInstance == null)
        {
            return null;
        }
        var type = System.Web.HttpContext.Current.ApplicationInstance.GetType();
        while (type != null && type.Namespace == "ASP")
        {
            type = type.BaseType;
        }
        return type == null ? null : type.Assembly;
    }
