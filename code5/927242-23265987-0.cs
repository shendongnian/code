    c.Register(Classes.FromAssemblyInThisApplication()
        .BasedOn<IFoo>()
        .Configure(x => Console.WriteLine(x.Implementation.Name)) // classes names
        .WithService.Select(new Type[] {typeof(IFoo)})
        .Configure(x => x.LifeStyle.Is(LifestyleType.Singleton)));
