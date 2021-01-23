        Kernel.Bind(scanner =>
        {
            scanner.FromAssembliesMatching("*")
                .SelectAllClasses()
                .InheritedFrom<AutoMapper.Profile>()
                .BindBase();
        });
