                Classes.FromAssembly(typeof(NHUserLoginRepository).Assembly)
                       .BasedOn<IRepository>()
                       .WithService.FromInterface().LifestyleTransient(),
                Classes.FromAssembly(typeof(UserLoginService).Assembly)
                       .BasedOn<IService>()
                       .WithService.FromInterface().LifestyleTransient(),
