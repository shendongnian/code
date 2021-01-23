        private static void RegisterServices(IKernel kernel)
        { 
            kernel.Bind<Entities>()
                  .ToSelf()
                  .InRequestScope();
            kernel.Bind<UserInfo>()
                  .ToProvider<UserInfoProvider>()
                  .InRequestScope();
        }
