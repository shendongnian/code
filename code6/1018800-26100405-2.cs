    container.AddFacility<TypedFactoryFacility>();
    container.Register(Component.For<IRecruiterFactory>()
                                .AsFactory());
    container.Register(Component.For<IRecruiter>()
                                .ImplementedBy<Recruiter>()
                                .LifestyleScoped<ArgScopeAccessor>());
