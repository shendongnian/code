    Container.Register(
            Types.FromAssembly(typeof(ICrudDal<>).Assembly)
                    .BasedOn(typeof(ICrudDal<>))
                    .Unless(t => t.IsAbstract)
                    .WithServiceAllInterfaces());
