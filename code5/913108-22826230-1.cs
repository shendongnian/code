    Register(Classes.FromAssembly(GetType().Assembly)
                .Where(x => x.Name.EndsWith("ViewModel"))
                .WithService.Self()
                .WithService.DefaultInterfaces()
                .Configure(x => x.LifeStyle.Is(LifestyleType.Transient)));
