    container.Register(Classes.FromThisAssembly()
                              .IncludeNonPublicTypes()
                              .BasedOn<IBoat>()
                              .WithService.FromInterface()
                              .LifestyleTransient());
