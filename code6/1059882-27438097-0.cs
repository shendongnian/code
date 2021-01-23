    var types = AppDomain.CurrentDomain.GetAssemblies()
        .SelectMany(s => s.GetTypes())
        .Where(p => typeof(ICommand).IsAssignableFrom(p));
    foreach (var type in types) {
        kernel.Bind<ICommand>().To(type);
    }
