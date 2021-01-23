    kernel.Bind(x =>
    {
        x.FromAssembliesInPath("somepath")
         .IncludeNonePublicTypes()
         .SelectAllClasses()
         .InheritedFrom<IPlugin()
         .BindDefaultInterface() // Binds the default interface to them;
    });
