    container.AddFacility<TypedFactoryFacility>();
    container.Register(
                     Component.For<IInvestigationBoxFactory>()
                              .AsFactory()
                   );
