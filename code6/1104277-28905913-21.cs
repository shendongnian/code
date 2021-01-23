    // Simple Injector v3.x
    container.RegisterSingleton<IMessageBox, StandardMessageBox>();
    container.Register<ManhattanProject>();
    container.RegisterCollection<IProjectSubPart>(new[] {
        typeof(ProjectSubPart1),
        typeof(ProjectSubPart2),
        typeof(ProjectSubPartN)
    });
    // Simple Injector v2.x
    container.RegisterSingle<IMessageBox, StandardMessageBox>();
    container.Register<ManhattanProject>();
    container.RegisterAll<IProjectSubPart>(new[] {
        typeof(ProjectSubPart1),
        typeof(ProjectSubPart2),
        typeof(ProjectSubPartN)
    });
