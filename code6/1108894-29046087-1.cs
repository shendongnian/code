    var registrations =
        from type in AssemblySource.Instance.GetExportedTypes()
        where typeof (IAction).IsAssignableFrom(type)
        where !typeof (ActionDecorator).IsAssignableFrom(type)
        where !type.IsAbstract
        select new {Name = type.Name, ImplementationType = type};
    var factory = new ActionFactory(container);
    foreach (var reg in registrations)
    {
        factory.Register(reg.ImplementationType, reg.Name);
    }
    container.RegisterSingle<IActionFactory>(factory);
