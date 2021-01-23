    var builder = new ContainerBuilder();
    builder.RegisterType<ObjectA>().As<IFirst>();
    builder.RegisterType<ObjectB>().As<ISecond>();
    builder.RegisterType<ObjectC>().As<IThird>();
    builder.RegisterType<ObjectD>().As<IFourth>();
    
    var container = builder.Build();
    
    // It's always good to use lifetime scopes and not
    // resolve directly from a container. You can see
    // here that I'm not doing anything special - this
    // lifetime scope will have the "default registrations."
    using(var scope = container.BeginLifetimeScope())
    {
    	// This will print:
    	// ObjectA -> ObjectB -> ObjectC -> ObjectD
    	var obj = scope.Resolve<IFirst>();
    	obj.WriteHierarchy();
    }
    
    // You can pass override registrations when you begin
    // a new lifetime scope. In this case, I'm overriding
    // the one service type deep in the hierarchy.
    using(var scope = container.BeginLifetimeScope(
        b => b.RegisterType<ObjectF>().As<IThird>()))
    {
    	// This will print:
    	// ObjectA -> ObjectB -> ObjectF -> ObjectD
    	var obj = scope.Resolve<IFirst>();
    	obj.WriteHierarchy();
    }
