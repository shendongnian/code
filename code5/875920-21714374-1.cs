    public class MyClassFactory:IMyClassFactory
    {
       readonly IKernel _kernel;
       public MyClassFactory(IKernel kernel)
       {
          _kernel=kernel;
       }
       public IMyClass Create(bool val)
       {
          return _kernel.Get<IMyClass>(new ConstructorArgument("val",val);
       }
    }
