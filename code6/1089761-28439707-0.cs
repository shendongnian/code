    foreach (Assembly a in AppDomain.CurrentDomain.GetAssemblies())// get all assemblies
    {
        foreach (Type t in a.GetTypes()) // get all types in the assembly
        {
            if( t.IsSubclassOf(typeof(CFilter) ) )// if the type inherit CFilter
            {
               var instance = (CFilter)Activator.CreateInstance(t);// create an instance ( with the default constructor ) of the type
               // use 'instance'
            }
        }
    }
