    container.Register(Classes.FromThisAssembly()
        .BasedOn<IHandlesEvent>()
        .If(t => t.Namespace == "WindsorTest.Select")
        .WithServiceAllInterfaces()
        );
