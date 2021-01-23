    Register(Classes.FromAssembly(GetType().Assembly)
                .Where(x => x.Name.EndsWith("ViewModel"))
                .WithService.Self()
                .WithService.AllInterfaces()
                .Configure(x => x.LifeStyle.Is(LifestyleType.Transient)));
