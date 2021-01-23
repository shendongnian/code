    // in another assembly
    class plugin {
       // take in required services in the constructor
       public plugin(ILogger logger) { ... }
    }
    
    var cb = new ContainerBuilder();
    // register services which the plugins will depend on
    cb.Register(cc => new Logger()).As<ILogger>();
    
    var types = // load types
    foreach (var type in types) {
        cb.RegisterType(type); // logger will be injected
    }
    var container = cb.Build();
    // to retrieve instances of the plugin
    var plugin = cb.Resolve(pluginType);
