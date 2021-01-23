        private static void RegisterServices(IKernel kernel)
        {
            // Authentication
            kernel.Bind<IAuthenticationService>().To<AuthenticationService>().InRequestScope();
            // Entity Framework Unit of Work
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>()
                .InRequestScope()
                .WithConstructorArgument("context", f => new DbContext("BlahBlahEntities"));
            // Document generator service
            kernel.Bind<IDocumentGeneratorService>().To<DummyDocumentGeneratorService>().InRequestScope();
            // Loggers
            kernel.Bind<ILog>().ToMethod(p => LogManager.GetLogger(p.Request.Target.Member.DeclaringType));
        }
