    public static class NinjectConfig
    {
        public static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            //Create the bindings
            kernel.Bind<IProductsRepository>().To<ProductRepository>();
            return kernel;
        }
    }
