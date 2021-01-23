    IEnumerable<Type> serviceTypes =
                types.Where(type => type.IsSubclassOf(typeof(WCFSvcBase)) 
                                       && !type.IsAbstract );
    foreach (Type serviceType in serviceTypes)
    {
        var members = serviceType.GetMembers();
        if (!members.Exists( member => member.GetCustomAttributes(true).Any(attrib => attrib.GetType() == typeof(WCFEndpointAttribute))))
        {
            Assert.Fail( "Found an incorrectly decorated svc!" )
        }
    }
