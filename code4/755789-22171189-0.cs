    public class DT_Kernel : StandardKernel
    {
        public DT_Kernel()
            : base(new MyModule())
        {
            if (!HasModule(typeof(FuncModule).FullName)) 
            {
                Load(new[] { new FuncModule() });
            }
        }
    }
