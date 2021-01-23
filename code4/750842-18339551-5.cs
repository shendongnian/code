    public static class Arbitrator
    {
        public static ITestClass getInstance(PersonChoice personChoice)
        {
            // Initialize container
            IUnityContainer unityContainer = new UnityContainer();
            unityContainer.AddNewExtension<Interception>();
            // Associate Interface with object to be intercepted
            unityContainer.RegisterType<ITestClass, TestClassPeter>(new InjectionConstructor(personChoice));
            unityContainer.Configure<Interception>()
                .SetInterceptorFor<ITestClass>(new InterfaceInterceptor());
            // return instance
            return unityContainer.Resolve<ITestClass>();
        }
    }
