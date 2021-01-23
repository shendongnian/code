            var kernel = new StandardKernel();
            /*add relevant loop/function here to make it recurse folders if need be*/
            kernel.Bind(s => s.FromAssembliesMatching("Library*.dll")
                .Select(type => type.IsClass && type.GetInterfaces().Contains(typeof(ILibrary)))
                .BindSingleInterface()
                .Configure(x=>x.InSingletonScope()));
