    public class BaseClass
    {
        private ITest _test;
        public BaseClass(ITest test) //injected, no knowledge of IUnityContainer required
        {
           _test = test;
        }
    }
    //elsewhere:
    container.Resolve<BaseClass>();
