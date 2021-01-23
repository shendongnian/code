    static object TraversePropertyInfo(object obj, Assembly assembly)
    {
        Console.WriteLine(obj.GetType().Name);
        // we stop the iteration when we reached the root-class "object" 
        // which won´t add any custom properties
        if (obj.GetType() == typeof(object) return obj;
        foreach(PropertyInfo pi in obj.GetType().GetProperties())
        {
            if(pi.PropertyType.IsClass && pi.PropertyType.Namespace != "System")
            {
                if(pi.PropertyType.UnderlyingSystemType.GenericTypeArguments.Count() > 0)
                {
                    Console.WriteLine("\tIList<{0}>", pi.Name);
                }
                else
                {
                    Console.WriteLine("\t{0}\t<class>", pi.Name);
                    object child = Activator.CreateInstance(assembly.GetType(pi.PropertyType.FullName));  // create the child instance
                    child = TraversePropertyInfo(child, child.GetType().Assembly);
                    obj.GetType().GetProperty(pi.Name).SetValue(obj, child);                              // set the child on the parent
                    // this will do the recursion
                    return obj;
                }
            }
            else
            {
                Console.WriteLine("\t{0}\t{1}", pi.Name, pi.PropertyType);
            }
        }
        return obj;
    }
