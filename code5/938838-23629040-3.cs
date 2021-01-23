    kernel.Bind(x =>
    {
        x.FromAssembliesInPath("somepath")
         .IncludingNonePublicTypes()
         .SelectAllClasses()
         .InheritedFrom<IPlugin()
         .BindDefaultInterface() // Binds the default interface to them;
    });
