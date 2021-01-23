            var kernel = new StandardKernel();
            kernel.Bind(
                x =>
                x.FromAssembliesMatching("*")
                    .IncludingNonePublicTypes()
                    .SelectAllClasses()
                    .InheritedFrom(typeof(IPersist<>))
                    .BindSingleInterface());
