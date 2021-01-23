    public class Z
    {
        public Z(IEnumerable<Y> dependencies)
        {
            if (dependencies == null) throw new ArgumentNullException("dependencies");
            _dependencies = dependencies;
        }
    }
    static void Main() // or other entry point
    {
        var kernel = new StandardKernel();
        kernel.Bind<Z>().To<ZImplementation>();
        kernel.Bind<Y>().To<YImplementation1>().WithConstructorArgument("c", "string to inject 1");
        kernel.Bind<Y>().To<YImplementation2>().WithConstructorArgument("c", "string to inject 2");
    }
