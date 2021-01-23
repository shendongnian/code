    public class Global : NinjectHttpApplication
    {
        public static IKernel Kernel;
    
        protected override IKernel CreateKernel()
        {
            IKernel kernel = new StandardKernel(new YourModule());
            return kernel;
        }
    }
    public class MyServerControl : CompositeControl
    {
        public ICalculate Calculate { get; set; }
    
        public MyServerControl()
        {
            Calculate = Global.Kernel.Get<ICalculate>(); // like service locator
        }
    }
