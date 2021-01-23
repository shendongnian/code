    class Program
    {
        private static StandardKernel _kernel;
        static void Main(string[] args)
        {
            _kernel = new StandardKernel();
            _kernel.Bind<IAdapter>().To<Adapter<AdapteeA>>();
            var adapter = _kernel.Get<IAdapter>();
            adapter.MethodA();
        }
    }
