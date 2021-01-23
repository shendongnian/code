    typeof(RepositoryBase).Assembly
                          .CreatableTypes()
                          .EndingWith("Repository")
                          .AsInterfaces()
                          .RegisterAsLazySingleton();
