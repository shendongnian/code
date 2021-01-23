    public static class NinjectKernel
    {
        public static IKernel Kernel = new StandardKernel();
        static NinjectKernel()
        {
            Kernel.Bind<IMyRepository>().To<MyRepositoryImpl>().InRequestScope();
        }
    }
