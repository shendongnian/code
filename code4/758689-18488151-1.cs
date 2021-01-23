    var builder = new Autofac.ContainerBuilder();
    builder.RegisterType<StrategyA>().As<IProcessor>().Keyed<IProcessor>(typeof(ItemA).Name).InstancePerDependency();
    builder.RegisterType<StrategyB>().As<IProcessor>().Keyed<IProcessor>(typeof(ItemB).Name).InstancePerDependency();
    builder.Register<Func<string, IProcessor>>(c => {
    	var ctx = c.Resolve<IComponentContext>();
    	return (s) => ctx.ResolveKeyed<IProcessor>(s);
    });
    builder.RegisterType<MyServiceConsumer>().As<IConsumer>();
    
    var container = builder.Build();
    
    var consumer = container.Resolve<IConsumer>().DoStuff(new ItemB()).Dump();
