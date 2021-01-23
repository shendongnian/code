    container.Register<MyInterfaceImplementor1>();
    container.Register<MyInterfaceImplementor2>();
    container.RegisterWithContext<IMyInterface>(context =>
        context.ImplementationType.Namespace.Contains("Administrator")
            ? container.GetInstance<MyInterfaceImplementor1>()
            : container.GetInstance<MyInterfaceImplementor2>());
