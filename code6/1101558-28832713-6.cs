        // don't do that
        ContainerBuilder builder = new ContainerBuilder();
        builder.RegisterType<Pouet>().Named<Pouet>("initial");
        builder.RegisterType<Foo>().Named<Foo>("initial");
        builder.Register(c => c.ResolveNamed<Pouet>("initial", TypedParameter.From<Foo>(c.Resolve<IEnumerable<Meta<Foo>>>().Where(m => (Int32)m.Metadata["Bar"] == 1).Select(m => m.Value).First()))).As<Pouet>().WithMetadata("Bar", 1);
        builder.Register(c => c.ResolveNamed<Pouet>("initial", TypedParameter.From<Foo>(c.Resolve<IEnumerable<Meta<Foo>>>().Where(m => (Int32)m.Metadata["Bar"] == 1).Select(m => m.Value).First()))).As<Pouet>().WithMetadata("Bar", 2);
        builder.Register(c => c.ResolveNamed<Foo>("initial",TypedParameter.From<IBar>(c.Resolve<IEnumerable<Meta<IBar>>>().Where(m => (Int32)m.Metadata["Bar"] == 1).Select(m => m.Value).First()))).As<Foo>().WithMetadata("Bar", 1);
        builder.Register(c => c.ResolveNamed<Foo>("initial",TypedParameter.From<IBar>(c.Resolve<IEnumerable<Meta<IBar>>>().Where(m => (Int32)m.Metadata["Bar"] == 2).Select(m => m.Value).First()))).As<Foo>().WithMetadata("Bar", 2);
        builder.RegisterType<Bar1>().As<IBar>().WithMetadata("Bar", 1);
        builder.RegisterType<Bar2>().As<IBar>().WithMetadata("Bar", 2);
        IContainer container = builder.Build();
        IEnumerable<Pouet> pouets = container.Resolve<IEnumerable<Pouet>>();
        Console.WriteLine(pouets.Count()); // => 2 !
